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
using System.Linq.Dynamic;
using System.Data.Entity;
using System.IO;
using System.Web;

namespace RojgarMantra.Service
{
    public interface IJobAlertDetailsService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<bool> Save(JobAlertDetailsAddEditModel model);
        Task<JobAlertDetailsAddEditModel> Get(int id);
        Task<bool> Delete(int id);
    }
    public class JobAlertDetailsService : IJobAlertDetailsService
    {

        private IUnitOfWork _uow;
        public JobAlertDetailsService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var emp = _uow.JobAlertDetailsRepository.Query();

            if (!string.IsNullOrEmpty(model.Search))
            {
                emp = emp.Where(x => x.Designation.ToLower().Contains(model.Search.ToLower())
                         || x.Location.ToLower().Contains(model.Search.ToLower())
                         || x.YearOfExperience.Equals(model.Search)
                         || x.WorkExperience.Equals(model.Search)
                         || x.Email.ToLower().Contains(model.Search.ToLower())
                         || x.Skills.ToLower().Contains(model.Search.ToLower())
                         || x.NoticePeriod.ToLower().Contains(model.Search.ToLower())
                         || x.NameOfJobAlert.ToLower().Contains(model.Search.ToLower())
                         || x.Role.ToLower().Contains(model.Search.ToLower()));
            }

            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                emp = emp.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await emp.CountAsync();

            var data = emp.Skip(model.Start).Take(model.Length).AsEnumerable().
                Select(x => new JobAlertDetailsListModel
                {
                    Id = x.Id,
                    Designation = x.Designation,
                    Location = x.Location,
                    Email = x.Email,
                    YearOfExperience = x.YearOfExperience,
                    NameOfJobAlert = x.NameOfJobAlert,
                    JobCategory = x.JobCategory,
                    WorkExperience = x.WorkExperience,
                    Role = x.Role,
                    Skills = x.Skills,
                    NoticePeriod = x.NoticePeriod,
                }).ToList();

            return new ListOutputModel
            {
                Data = data,
                RecordsTotal = recordsTotal
            };
        }

        public async Task<bool> Save(JobAlertDetailsAddEditModel model)
        {
            JobAlertDetails jobAlertDetails;

            if (model.Id == 0)
            {
                jobAlertDetails = new JobAlertDetails();
                await _uow.JobAlertDetailsRepository.Add(jobAlertDetails);
            }
            else
            {
                jobAlertDetails = await _uow.JobAlertDetailsRepository.Get(model.Id);
                await _uow.JobAlertDetailsRepository.Update(jobAlertDetails);
            }
            jobAlertDetails.Id = model.Id;
            jobAlertDetails.UserId = model.UserId;
            jobAlertDetails.Designation = model.Designation;
            jobAlertDetails.Location = model.Location;
            jobAlertDetails.YearOfExperience = model.YearOfExperience;
            jobAlertDetails.NameOfJobAlert = model.NameOfJobAlert;
            jobAlertDetails.JobCategory = model.JobCategory;
            jobAlertDetails.WorkExperience = model.WorkExperience;
            jobAlertDetails.Email = model.Email;
            jobAlertDetails.Role = model.Role;
            jobAlertDetails.Skills = model.Skills;
            jobAlertDetails.NoticePeriod = model.NoticePeriod;
            jobAlertDetails.ExpectedCTCLac = model.ExpectedCTCLac;
            jobAlertDetails.ExpectedCTCThousand = model.ExpectedCTCThousand;
            jobAlertDetails.NegotiableExpectedCTC = model.NegotiableExpectedCTC;
            return await _uow.Save();
        }

        public async Task<JobAlertDetailsAddEditModel> Get(int id)
        {
            var jobAlertDetails = await _uow.JobAlertDetailsRepository.Get(id);
            var result = new JobAlertDetailsAddEditModel
            {
                Id = jobAlertDetails.Id,
                UserId = jobAlertDetails.UserId,
                Designation = jobAlertDetails.Designation,
                Location = jobAlertDetails.Location,
                YearOfExperience = jobAlertDetails.YearOfExperience,
                NameOfJobAlert = jobAlertDetails.NameOfJobAlert,
                JobCategory = jobAlertDetails.JobCategory,
                WorkExperience = jobAlertDetails.WorkExperience,
                Email = jobAlertDetails.Email,
                Role = jobAlertDetails.Role,
                Skills = jobAlertDetails.Skills,
                NoticePeriod = jobAlertDetails.NoticePeriod,
                ExpectedCTCLac = jobAlertDetails.ExpectedCTCLac,
                ExpectedCTCThousand = jobAlertDetails.ExpectedCTCThousand,
                NegotiableExpectedCTC = jobAlertDetails.NegotiableExpectedCTC,
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _uow.JobAlertDetailsRepository.Delete(id);

            return await _uow.Save();
        }
    }
}
