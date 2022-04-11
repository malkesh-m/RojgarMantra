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
    public interface IJobDetailsService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<bool> Save(JobDetailsAddEditModel model);
        Task<JobDetailsAddEditModel> Get(int id);
        Task<bool> Delete(int id);
    }
    public class JobDetailsService : IJobDetailsService
    {

        private IUnitOfWork _uow;
        public JobDetailsService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var emp = _uow.JobDetailsRepository.Query();

            if (!string.IsNullOrEmpty(model.Search))
            {
                emp = emp.Where(x => x.FirstName.ToLower().Contains(model.Search.ToLower())
                         || x.CompanyName.ToLower().Contains(model.Search.ToLower())
                         || x.JobTitle.ToLower().Contains(model.Search.ToLower())
                         || x.Email.ToLower().Contains(model.Search.ToLower())
                         || x.Skills.ToLower().Contains(model.Search.ToLower())
                         || x.JobType.ToLower().Contains(model.Search.ToLower())
                         || x.LocationOfJob.ToLower().Contains(model.Search.ToLower()));
            }

            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                emp = emp.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await emp.CountAsync();

            var data = emp.Skip(model.Start).Take(model.Length).AsNoTracking().
                Select(x => new JobDetailsListModel
                {
                    Id = x.Id,
                    JobTitle = x.JobTitle,
                    FirstName = x.FirstName,
                    Email = x.Email,
                    CompanyName = x.CompanyName,
                    ContactNumber = x.ContactNumber,
                    Skills = x.Skills,
                    JobType = x.JobType,
                    NumberOfOpenings = x.NumberOfOpenings,
                    LocationOfJob = x.LocationOfJob,
                    MinWorkExperience = x.MinWorkExperience,
                    MaxWorkExperience = x.MinWorkExperience
                }).ToList();

            return new ListOutputModel
            {
                Data = data,
                RecordsTotal = recordsTotal
            };
        }

        public async Task<bool> Save(JobDetailsAddEditModel model)
        {
            JobDetails jobDetails;

            if (model.Id == 0)
            {
                jobDetails = new JobDetails();
                await _uow.JobDetailsRepository.Add(jobDetails);
            }
            else
            {
                jobDetails = await _uow.JobDetailsRepository.Get(model.Id);
                await _uow.JobDetailsRepository.Update(jobDetails);
            }
            jobDetails.Id = model.Id;
            jobDetails.UserId = model.UserId;
            jobDetails.FirstName = model.FirstName;
            jobDetails.Email = model.Email;
            jobDetails.ContactNumber = model.ContactNumber;
            jobDetails.CompanyName = model.CompanyName;
            jobDetails.Website = model.Website;
            jobDetails.JobType = model.JobType;
            jobDetails.JobStartDate = model.JobStartDate;
            jobDetails.JobTitle = model.JobTitle;
            jobDetails.MinWorkExperience = model.MinWorkExperience;
            jobDetails.MaxWorkExperience = model.MaxWorkExperience;
            jobDetails.MinAnnualSalary = model.MinAnnualSalary;
            jobDetails.MaxAnnualSalary = model.MaxAnnualSalary;
            jobDetails.ContactNumber = model.ContactNumber;
            jobDetails.NumberOfOpenings = model.NumberOfOpenings;
            jobDetails.LocationOfJob = model.LocationOfJob;
            jobDetails.Skills = model.Skills;
            jobDetails.JobEndDate = model.JobEndDate;
            jobDetails.PostEndDate = model.PostEndDate;
            jobDetails.JobDescription = model.JobDescription;

            jobDetails.HSC = model.HSC;
            jobDetails.SSC = model.SSC;
            jobDetails.DegreeId =Convert.ToInt32(model.Graduation);
            jobDetails.PostDegreeId = Convert.ToInt32(model.PostGraduation);
            return await _uow.Save();
        }

        public async Task<JobDetailsAddEditModel> Get(int id)
        {
            var jobDetails = await _uow.JobDetailsRepository.Get(id);
            var result = new JobDetailsAddEditModel
            {
                Id = jobDetails.Id,
                UserId = jobDetails.UserId,
                FirstName = jobDetails.FirstName,
                Email = jobDetails.Email,
                ContactNumber = jobDetails.ContactNumber,
                CompanyName = jobDetails.CompanyName,
                Website = jobDetails.Website,
                JobType = jobDetails.JobType,
                JobStartDate = Convert.ToDateTime(jobDetails.JobStartDate),
                JobTitle = jobDetails.JobTitle,
                MinWorkExperience = jobDetails.MinWorkExperience,
                MaxWorkExperience = jobDetails.MaxWorkExperience,
                MinAnnualSalary = jobDetails.MinAnnualSalary,
                MaxAnnualSalary = jobDetails.MaxAnnualSalary,
                NumberOfOpenings = jobDetails.NumberOfOpenings,
                LocationOfJob = jobDetails.LocationOfJob,
                Skills = jobDetails.Skills,
                JobEndDate = Convert.ToDateTime(jobDetails.JobEndDate),
                PostEndDate = Convert.ToDateTime(jobDetails.PostEndDate),
                JobDescription = jobDetails.JobDescription,
                HSC = jobDetails.HSC,
                SSC = jobDetails.SSC,
                Graduation = jobDetails.DegreeId.ToString(),
                PostGraduation = jobDetails.PostDegreeId.ToString(),
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _uow.JobDetailsRepository.Delete(id);

            return await _uow.Save();
        }
    }
}
