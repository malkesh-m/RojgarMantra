using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RojgarMantra.Core.Models;
using RojgarMantra.Data.Entities;
using RojgarMantra.Repo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Data.Entity;
using System.IO;
using System.Web;
using System.Transactions;
using System.Data.Entity.Validation;
using RojgarMantra.Data;

namespace RojgarMantra.Service
{
    public interface IUserTrainingInstituteService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<string> Save(UserTrainingInstituteAddEditModel model);
        Task<UserTrainingInstituteAddEditModel> Get(int id);
        Task<bool> Delete(int id);
    }
    public class UserTrainingInstituteService : IUserTrainingInstituteService
    {

        private IUnitOfWork _uow;
        public UserTrainingInstituteService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var emp = _uow.UserTrainingInstituteRepository.Query();

            if (!string.IsNullOrEmpty(model.Search))
            {
                emp = emp.Where(x => x.TrainingInstituteName.Equals(model.Search)
                         || x.ContactNumber.Equals(model.Search)
                         || x.Email.ToLower().Contains(model.Search.ToLower())
                         || x.Designation.Name.ToLower().Contains(model.Search.ToLower())
                         || x.Address.ToLower().Contains(model.Search.ToLower())
                         || x.CompanyLink.ToLower().Contains(model.Search.ToLower())
                         || x.WorkExperience.Equals(model.Search));
            }

            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                emp = emp.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await emp.CountAsync();

            var data = emp.Skip(model.Start).Take(model.Length).AsNoTracking().
                Select(x => new UserTrainingInstituteListModel
                {
                    Id = x.Id,

                    TrainingInstituteName = x.TrainingInstituteName,
                    Email = x.Email,
                    ContactNumber = x.ContactNumber,
                    CompanyLink = x.CompanyLink,
                    Address = x.Address,
                    Designation = x.Designation.Name,
                    WorkExperience = x.WorkExperience,
                }).ToList();

            return new ListOutputModel
            {
                Data = data,
                RecordsTotal = recordsTotal
            };
        }

        public string AddCompanyLogo(HttpPostedFileBase file)
        {
            var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", "jpeg"
            };

            var filename = Path.GetFileName(file.FileName);
            var extension = Path.GetExtension(file.FileName);
            if (allowedExtensions.Contains(extension))
            {
                string name = Guid.NewGuid().ToString() + "_" + extension;
                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/CompanyLogo_Img"), name);
                file.SaveAs(path);
                return path;
            }
            return "Not Supported";
        }

        public async Task<string> Save(UserTrainingInstituteAddEditModel model)
        {
            UserTrainingInstitute user;
            ApplicationUserStore store = new ApplicationUserStore(_uow.DbContext);
            ApplicationUserManager userManager = new ApplicationUserManager(store);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_uow.DbContext));
            IdentityResult result;
            if (model.Id == 0)
            {
                ApplicationUser users = new ApplicationUser();
                users.Email = model.Email;
                users.UserName = model.Email;
                users.FirstName = model.FirstName;
                users.MiddleName = model.MiddleName;
                users.LastName = model.LastName;

                result = await userManager.CreateAsync(users, model.Password);

                if (result.Succeeded)
                {
                    userManager.AddToRole(users.Id, "TrainingInstitute");
                    user = new UserTrainingInstitute();
                    await _uow.UserTrainingInstituteRepository.Add(user);
                    user.UserId = users.Id;
                    user.TrainingInstituteName = model.TrainingInstituteName;
                    user.Email = model.Email;
                    user.ContactNumber = Convert.ToDouble(model.ContactNumber);
                    user.CompanyLink = model.CompanyLink;
                    user.Address = model.Address;
                    user.DesignationId = Convert.ToInt32(model.Designation);
                    user.WorkExperience = model.WorkExperience;
                    if (model.TrainingInstituteLogo != null)
                        user.TrainingInstituteLogo = AddCompanyLogo(model.TrainingInstituteLogo);
                    var check = await _uow.Save();
                    if (check)
                    {
                        return "Success";
                    }
                }
                else
                {
                    return "User already exist";
                }
            }
            else
            {
                user = await _uow.UserTrainingInstituteRepository.Get(model.Id);
                ApplicationUser users = await userManager.FindByIdAsync(user.UserId);
                result = await userManager.UpdateAsync(users);
                if (result.Succeeded)
                {

                    await _uow.UserTrainingInstituteRepository.Update(user);
                    user.TrainingInstituteName = model.TrainingInstituteName;
                    user.Email = model.Email;
                    user.ContactNumber = Convert.ToDouble(model.ContactNumber);
                    user.CompanyLink = model.CompanyLink;
                    user.Address = model.Address;
                    user.DesignationId = Convert.ToInt32(model.Designation);
                    user.WorkExperience = model.WorkExperience;
                    if (model.TrainingInstituteLogo != null)
                        user.TrainingInstituteLogo = AddCompanyLogo(model.TrainingInstituteLogo);
                    var check = await _uow.Save();
                    if (check)
                    {
                        return "Success";
                    }
                }
            }

            return "Failed";
        }
    
        public async Task<UserTrainingInstituteAddEditModel> Get(int id)
        {
            var emp = await _uow.UserTrainingInstituteRepository.Get(id);
            ApplicationUserStore store = new ApplicationUserStore(_uow.DbContext);
            ApplicationUserManager userManager = new ApplicationUserManager(store);
            ApplicationUser user = await userManager.FindByIdAsync(emp.UserId);
            var result = new UserTrainingInstituteAddEditModel
            {
                Id = emp.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                TrainingInstituteName = emp.TrainingInstituteName,
                Email = emp.Email,
                ContactNumber = emp.ContactNumber,
                CompanyLink = emp.CompanyLink,
                Address = emp.Address,
                Designation =Convert.ToString(emp.DesignationId),
                WorkExperience = emp.WorkExperience,
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _uow.UserTrainingInstituteRepository.Delete(id);

            return await _uow.Save();
        }
    }
}
