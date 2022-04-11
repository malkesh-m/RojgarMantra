using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RojgarMantra.Core.Models;
using RojgarMantra.Data.Entities;
using RojgarMantra.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Dynamic;
using System.IO;
using System.Web;

namespace RojgarMantra.Service
{
    public interface IUserJobSeekerService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<string> Save(UserJobSeekerAddEditModel model);
        Task<UserJobSeekerAddEditModel> Get(int id);
        Task<bool> Delete(int id);
    }
    public class UserJobSeekerService : IUserJobSeekerService
    {
        private IUnitOfWork _uow;
        public UserJobSeekerService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var emp = _uow.UserJobSeekerRepository.Query();

            if (!string.IsNullOrEmpty(model.Search))
            {
                emp = emp.Where(x => x.FirstName.ToLower().Contains(model.Search.ToLower())
                         || x.MiddleName.ToLower().Contains(model.Search.ToLower())
                         || x.ContactNumber.Equals(model.Search)
                         || x.Email.ToLower().Contains(model.Search.ToLower())
                         || x.Designation.Name.ToLower().Contains(model.Search.ToLower())
                         || x.Role.Name.ToLower().Contains(model.Search.ToLower())
                         || x.LastName.ToLower().Contains(model.Search.ToLower())
                         || x.Country.Name.ToLower().Contains(model.Search.ToLower())
                         || x.State.Name.ToLower().Contains(model.Search.ToLower())
                         || x.City.Name.ToLower().Contains(model.Search.ToLower())
                         || x.PermanentLocation.ToLower().Contains(model.Search.ToLower())
                         || x.PrefferredLocation.ToLower().Contains(model.Search.ToLower())
                         || x.CurrentAddress.ToLower().Contains(model.Search.ToLower())
                         || x.Skills.ToLower().Contains(model.Search.ToLower())
                         || x.GraduationCompletionInstituteUniversity.ToLower().Contains(model.Search.ToLower())
                         || x.PostGraduationCompletionInstituteUniversity.ToLower().Contains(model.Search.ToLower())
                         || x.DegreeName.Name.ToLower().Contains(model.Search.ToLower())
                         || x.PostDegreeName.Name.ToLower().Contains(model.Search.ToLower())
                         || x.CompanyName.ToLower().Contains(model.Search.ToLower())
                         || x.PrevCompanyName.ToLower().Contains(model.Search.ToLower())
                         || x.CourseName.ToLower().Contains(model.Search.ToLower())
                         || x.SelectLanguage.ToLower().Contains(model.Search.ToLower())
                         || x.AlternateContactNumber.Equals(model.Search));
            }

            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                emp = emp.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await emp.CountAsync();

            var data = emp.Skip(model.Start).Take(model.Length).AsNoTracking().
                Select(x => new UserJobSeekerListModel
                {
                    Id = x.Id,


                   // UserName = x.UserName,
                    FirstName = x.FirstName,
                   // MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    CurrentAddress = x.CurrentAddress,
                    Email = x.Email,
                   ContactNumber =x.ContactNumber,
                    PrefferredLocation = x.PrefferredLocation,
                    
                    Skills = x.Skills,
                    Experience = x.Experience,
                    Role = x.Role.Name,
                    Designation = x.Designation.Name,
                   
                    DegreeName = x.DegreeName.Name,
                    PostDegreeName = x.PostDegreeName.Name,
                    

                }).ToList();

            return new ListOutputModel
            {
                Data = data,
                RecordsTotal = recordsTotal
            };
        }
        public string AddResume(HttpPostedFileBase file)
        {
            var allowedExtensions = new[] {
            ".doc", ".docx", ".pdf"
            };

            var filename = Path.GetFileName(file.FileName);
            var extension = Path.GetExtension(file.FileName);
            if (allowedExtensions.Contains(extension))
            {
                string name = Guid.NewGuid().ToString() + "_" + extension;
                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/Document"), name);
                file.SaveAs(path);
                return path;
            }
            return "Not Supported";
        }
        public async Task<string> Save(UserJobSeekerAddEditModel model)
        {
            UserJobSeeker user;
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
                    userManager.AddToRole(users.Id, "JobSeeker");
                    user = new UserJobSeeker();
                    await _uow.UserJobSeekerRepository.Add(user);
                    user.UserId = users.Id;
                    user.UserName = model.Email;
                    user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.MiddleName = model.MiddleName;
                    user.LastName = model.LastName;
                    user.MarriedStatus = model.MarriedStatus;
                    user.Gender = model.Gender;
                    user.DateOfBirth = Convert.ToDateTime(model.DateOfBirth);
                    user.PhysicallyChallenged = model.PhysicallyChallenged;
                    user.ContactNumber = Convert.ToDouble(model.ContactNumber);
                    user.AlternateContactNumber = Convert.ToDouble(model.AlternateContactNumber);
                    user.CountryId = Convert.ToInt32(model.Country);
                    user.StateId = Convert.ToInt32(model.State);
                    user.CityId = Convert.ToInt32(model.City);
                    user.PermanentLocation = model.PermanentLocation;
                    user.PrefferredLocation = model.PrefferredLocation;
                    user.CurrentAddress = model.CurrentAddress;
                    user.CompanyName = model.CompanyName;
                    user.RoleId =Convert.ToInt32(model.Role);
                    user.DesignationId = Convert.ToInt32(model.Designation);
                    user.TotalExperience = model.TotalExperience;
                    user.Skills = model.Skills;
                    user.CurrentCTCLac = model.CurrentCTCLac;
                    user.CurrentCTCThousand = model.CurrentCTCThousand;
                    user.ExpectedCurrentCTCThousand = model.ExpectedCurrentCTCThousand;
                    user.ExpectedCurrentCTCLac = model.ExpectedCurrentCTCLac;
                    user.NegotiableExpectedCTC = model.NegotiableExpectedCTC;
                    user.NoticePeriod = model.NoticePeriod;
                    user.NegotiableNoticePeriod = model.NegotiableNoticePeriod;
                    user.PrevCompanyName = model.PrevCompanyName;
                    user.From = model.From;
                    user.To = model.To;
                    user.Experience = model.Experience;
                    user.SSCMarks =Convert.ToInt32(model.SSCMarks);
                    user.SSCCompletionYear = model.HSCCompletionYear;
                    user.HSCMarks = Convert.ToInt32(model.HSCMarks);
                    user.HSCCompletionYear = model.HSCCompletionYear;
                    user.DegreeNameId = Convert.ToInt32(model.DegreeName);
                    user.PostDegreeNameId = Convert.ToInt32(model.PostDegreeName);
                    user.GraduationMarks = Convert.ToInt32(model.GraduationMarks);
                    user.GraduationCompletionYear = model.GraduationCompletionYear;
                    user.GraduationCompletionInstituteUniversity = model.GraduationCompletionInstituteUniversity;
                    user.PostGraduationMarks = Convert.ToInt32(model.PostGraduationMarks);
                    user.PostGraduationCompletionYear = model.PostGraduationCompletionYear;
                    user.PostGraduationCompletionInstituteUniversity = model.PostGraduationCompletionInstituteUniversity;
                    user.CourseName = model.CourseName;
                    user.CourseCompletionDuration = model.CourseCompletionDuration;
                    user.SelectLanguage = model.SelectLanguage;
                    user.Read = model.Read;
                    user.Write = model.Write;
                    user.Speak = model.Speak;
                    if (model.Resume != null)
                      user.Resume = AddResume(model.Resume);
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
                user = await _uow.UserJobSeekerRepository.Get(model.Id);
                ApplicationUser users = await userManager.FindByIdAsync(user.UserId);
                if (!string.IsNullOrEmpty(model.Password))
                {
                    var result1 = await userManager.CheckPasswordAsync(users, model.Password);
                    if (!result1)
                    {
                        await userManager.CheckPasswordAsync(users, model.Password);
                    }
                }
                result = await userManager.UpdateAsync(users);
                if (result.Succeeded)
                {

                    await _uow.UserJobSeekerRepository.Update(user);
                    user.UserId = users.Id;
                    user.UserName = model.Email;
                    user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.MiddleName = model.MiddleName;
                    user.LastName = model.LastName;
                    user.MarriedStatus = model.MarriedStatus;
                    user.Gender = model.Gender;
                    user.DateOfBirth = Convert.ToDateTime(model.DateOfBirth);
                    user.PhysicallyChallenged = model.PhysicallyChallenged;
                    user.ContactNumber = Convert.ToDouble(model.ContactNumber);
                    user.AlternateContactNumber = Convert.ToDouble(model.AlternateContactNumber);
                    user.CountryId =Convert.ToInt32(model.Country);
                    user.StateId = Convert.ToInt32(model.State);
                    user.CityId = Convert.ToInt32(model.City);
                    user.PermanentLocation = model.PermanentLocation;
                    user.PrefferredLocation = model.PrefferredLocation;
                    user.CurrentAddress = model.CurrentAddress;
                    user.CompanyName = model.CompanyName;
                    user.RoleId = Convert.ToInt32(model.Role);
                    user.DesignationId = Convert.ToInt32(model.Designation);
                    user.TotalExperience = model.TotalExperience;
                    user.Skills = model.Skills;
                    user.CurrentCTCLac = model.CurrentCTCLac;
                    user.CurrentCTCThousand = model.CurrentCTCThousand;
                    user.ExpectedCurrentCTCThousand = model.ExpectedCurrentCTCThousand;
                    user.ExpectedCurrentCTCLac = model.ExpectedCurrentCTCLac;
                    user.NegotiableExpectedCTC = model.NegotiableExpectedCTC;
                    user.NoticePeriod = model.NoticePeriod;
                    user.NegotiableNoticePeriod = model.NegotiableNoticePeriod;
                    user.PrevCompanyName = model.PrevCompanyName;
                    user.From = model.From;
                    user.To = model.To;
                    user.Experience = model.Experience;
                    user.SSCMarks = Convert.ToInt32(model.SSCMarks);
                    user.SSCCompletionYear = model.HSCCompletionYear;
                    user.HSCMarks = Convert.ToInt32(model.HSCMarks);
                    user.HSCCompletionYear = model.HSCCompletionYear;
                    user.DegreeNameId = Convert.ToInt32(model.DegreeName);
                    user.PostDegreeNameId = Convert.ToInt32(model.PostDegreeName);
                    user.GraduationMarks = Convert.ToInt32(model.GraduationMarks);
                    user.GraduationCompletionYear = model.GraduationCompletionYear;
                    user.GraduationCompletionInstituteUniversity = model.GraduationCompletionInstituteUniversity;
                    user.PostGraduationMarks = Convert.ToInt32(model.PostGraduationMarks);
                    user.PostGraduationCompletionYear = model.PostGraduationCompletionYear;
                    user.PostGraduationCompletionInstituteUniversity = model.PostGraduationCompletionInstituteUniversity;
                    user.CourseName = model.CourseName;
                    user.CourseCompletionDuration = model.CourseCompletionDuration;
                    user.SelectLanguage = model.SelectLanguage;
                    user.Read = model.Read;
                    user.Write = model.Write;
                    user.Speak = model.Speak;
                    if (model.Resume != null)
                        user.Resume = AddResume(model.Resume);
                    var check = await _uow.Save();
                    if (check)
                    {
                        return "Success";
                    }
                }
            }
            return "Failed";

        }

        public async Task<UserJobSeekerAddEditModel> Get(int id)
        {
            var user = await _uow.UserJobSeekerRepository.Get(id);
            var result = new UserJobSeekerAddEditModel
            {
                Id = user.Id,
                // UserId = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                Email = user.Email,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                MarriedStatus = user.MarriedStatus,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                PhysicallyChallenged = user.PhysicallyChallenged,
                ContactNumber = user.ContactNumber,
                AlternateContactNumber = user.AlternateContactNumber,
                Country = user.CountryId.ToString(),
                State = user.StateId.ToString(),
                City = user.CityId.ToString(),
                PermanentLocation = user.PermanentLocation,
                PrefferredLocation = user.PrefferredLocation,
                CurrentAddress = user.CurrentAddress,
                CompanyName = user.CompanyName,
                Role =Convert.ToString(user.RoleId),
                Designation =Convert.ToString(user.DesignationId),
                TotalExperience = user.TotalExperience,
                Skills = user.Skills,
                CurrentCTCLac = user.CurrentCTCLac,
                CurrentCTCThousand = user.CurrentCTCThousand,
                ExpectedCurrentCTCThousand = user.ExpectedCurrentCTCThousand,
                ExpectedCurrentCTCLac = user.ExpectedCurrentCTCLac,
                NegotiableExpectedCTC = user.NegotiableExpectedCTC,
                NoticePeriod = user.NoticePeriod,
                NegotiableNoticePeriod = user.NegotiableNoticePeriod,
                PrevCompanyName = user.PrevCompanyName,
                From = user.From,
                To = user.To,
                Experience = user.Experience,
                SSCMarks = user.SSCMarks,
                SSCCompletionYear = user.HSCCompletionYear,
                HSCMarks = user.HSCMarks,
                HSCCompletionYear = user.HSCCompletionYear,
                DegreeName = Convert.ToString(user.DegreeNameId),
                PostDegreeName = Convert.ToString(user.PostDegreeNameId),
                GraduationMarks = user.GraduationMarks,
                GraduationCompletionYear = user.GraduationCompletionYear,
                GraduationCompletionInstituteUniversity = user.GraduationCompletionInstituteUniversity,
                PostGraduationMarks = user.PostGraduationMarks,
                PostGraduationCompletionYear = user.PostGraduationCompletionYear,
                PostGraduationCompletionInstituteUniversity = user.PostGraduationCompletionInstituteUniversity,
                CourseName = user.CourseName,
                CourseCompletionDuration = user.CourseCompletionDuration,
                SelectLanguage = user.SelectLanguage,
                Read = user.Read,
                Write = user.Write,
                Speak = user.Speak,
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _uow.UserJobSeekerRepository.Delete(id);

            return await _uow.Save();
        }
    }
}
