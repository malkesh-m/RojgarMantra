using RojgarMantra.Data.Entities;
using RojgarMantra.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using RojgarMantra.Core.Models;
using RojgarMantra.Data;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace RojgarMantra.Service
{
    public interface IUserService
    {
        Task<bool> Delete(string id);
        Task<UserAddEditModel> Get(string id);
        Task<IEnumerable<LookupModel1>> GetLookup();
        Task<ListOutputModel> GetPage(ListInputModel model);
        Task<bool> Save(UserAddEditModel model);
    }

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ListOutputModel> GetPage(ListInputModel model)
        {
            //int pageSize = model.Length != null ? Convert.ToInt32(model.Length) : 0;
            //int skip = model.Start != null ? Convert.ToInt32(model.Start) : 0;

            var query = _uow.UserRepository.Query();
            
            //Searh
                if (!string.IsNullOrEmpty(model.Search))
                {
                    query = query.Where(x => x.FirstName.ToLower().Contains(model.Search.ToLower())
                                              || x.MiddleName.ToLower().Contains(model.Search.ToLower())
                                              || x.LastName.ToLower().Contains(model.Search.ToLower())
                                              || x.Email.ToString().Contains(model.Search.ToLower())
                                              );
                }

            //SORT
            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                query = query.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await query.CountAsync();

            var data = await query.Skip(model.Start).Take(model.Length).ToListAsync();

            return new ListOutputModel
            {
                Data = data,
                RecordsTotal = recordsTotal
            };
        }

        public async Task<UserAddEditModel> Get(string id)
        {
            ApplicationUserStore store = new ApplicationUserStore(_uow.DbContext);
            ApplicationUserManager userManager = new ApplicationUserManager(store);
            ApplicationUser user = await userManager.FindByIdAsync(id);
            return new UserAddEditModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Country = user.Country,
                State = user.State,
                City = user.City,
               // Designation = user.Desig_Id,
                CurrentAddress = user.CurrentAddress,
                PermanentLocation = user.PermanentLocation,
               // Role = user.Users_RoleId,
                ContactNumber = Convert.ToDouble(user.PhoneNumber),
            };
        }

        public async Task<bool> Save(UserAddEditModel model)
        {
                ApplicationUserStore store = new ApplicationUserStore(_uow.DbContext);
                ApplicationUserManager userManager = new ApplicationUserManager(store);
            ApplicationUser user;
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_uow.DbContext));
            
               
            //user.PasswordHash = model.PasswordHash;
            IdentityResult result;
            if (string.IsNullOrEmpty(model.Id))
            {
                user = new ApplicationUser();
                user.Email = model.Email;
                user.UserName = model.Email;
                user.FirstName = model.FirstName;
                user.MiddleName = model.MiddleName;
                user.LastName = model.LastName;
                user.Country = model.Country;
                user.State = model.State;
                user.City = model.City;
             //   user.Desig_Id = model.Designation;
                user.CurrentAddress = model.CurrentAddress;
                user.PermanentLocation = model.PermanentLocation;
             //   user.Users_RoleId = model.Role;
                user.PhoneNumber = Convert.ToString(model.ContactNumber);
                result = await userManager.CreateAsync(user, model.Password);
                userManager.AddToRole(user.Id, "Admin");
            }
            else
            {
                user = await userManager.FindByIdAsync(model.Id);
                user.Email = model.Email;
                user.UserName = model.Email;
                user.FirstName = model.FirstName;
                user.MiddleName = model.MiddleName;
                user.LastName = model.LastName;
                user.Country = model.Country;
                user.State = model.State;
                user.City = model.City;
            //    user.Desig_Id = model.Designation;
                user.CurrentAddress = model.CurrentAddress;
                user.PermanentLocation = model.PermanentLocation;
            //    user.Users_RoleId = model.Role;
                user.PhoneNumber = Convert.ToString(model.ContactNumber);
                if (!string.IsNullOrEmpty(model.Password))
                {
                    var result1 = await userManager.CheckPasswordAsync(user, model.Password);
                    if (!result1)
                    {
                        await userManager.ChangePasswordAsync(user.Id, user.PasswordHash, model.Password);

                    }
                }
                result = await userManager.UpdateAsync(user);
                
            }

            return result.Succeeded;

            /*  user.FirstName = model.FirstName;
              user.MiddleName = model.MiddleName;
              user.LastName = model.LastName;
              user.UserName = model.Email;
              user.Email = model.Email;
              user.PasswordHash = model.PasswordHash;*/
            //user.MarriedStatus = model.MarriedStatus;
            //user.Gender = model.Gender;
            //user.AlternateContactNumber = model.AlternateContactNumber;

            //user.PrefferredLocation = model.PrefferredLocation;
            //user.Skills = model.Skills;
            //user.SSCMarks = model.SSCMarks;
            //user.SSCCompletionYear = model.SSCCompletionYear;
            //user.HSCMarks = model.HSCMarks;
            //user.HSCCompletionYear = model.HSCCompletionYear;
            //user.DegreeName = model.DegreeName;
            //user.GraduationMarks = model.GraduationMarks;
            //user.GraduationCompletionYear = model.GraduationCompletionYear;
            //user.GraduationCompletionInstituteUniversity = model.GraduationCompletionInstituteUniversity;
            //user.PostDegreeName = model.PostDegreeName;
            //user.PostGraduationMarks = model.PostGraduationMarks;
            //user.PostGraduationCompletionYear = model.PostGraduationCompletionYear;
            //user.PostGraduationCompletionInstituteUniversity = model.PostGraduationCompletionInstituteUniversity;
        }

        public async Task<bool> Delete(string id)
        {
            ApplicationUserStore store = new ApplicationUserStore(_uow.DbContext);
            ApplicationUserManager userManager = new ApplicationUserManager(store);
            ApplicationUser user = await userManager.FindByIdAsync(id);
            var result = await userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<IEnumerable<LookupModel1>> GetLookup()
        {
            return await _uow.UserRepository.Query().Select(s => new LookupModel1
            {
                Id = s.Id,
                Name = s.FirstName + " " + s.LastName
            }).ToListAsync();
        }
    }
}
