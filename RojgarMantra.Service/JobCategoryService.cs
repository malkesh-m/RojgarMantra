using Microsoft.AspNetCore.Http;
using RojgarMantra.Core.Models;
using RojgarMantra.Data.Entities;
using RojgarMantra.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace RojgarMantra.Service
{
    public interface IJobCategoryService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<bool> Delete(int id);
        Task<JobCategoryAddEditModel> Get(int id);
        Task<IEnumerable<LookupModel>> GetLookup();
        /* Task<bool> Add(JobCategoryListModel model);
         Task<bool> Update(JobCategoryListModel model);*/

        Task<bool> Save(JobCategoryAddEditModel model);
    }

    public class JobCategoryService : IJobCategoryService
    {
        private readonly IUnitOfWork _uow;

        public JobCategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var jobs = _uow.JobCategoryRepository.Query();

            //search job
            if (!string.IsNullOrEmpty(model.Search))
            {
                jobs = jobs.Where(x => x.Name.ToLower().Contains(model.Search.ToLower()));
            }

            //sort column
            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                jobs = jobs.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await jobs.CountAsync();

            var data = jobs.Skip(model.Start).Take(model.Length).AsEnumerable().
                Select(x => new JobCategoryListModel
                {
                    Id = x.Id,
                    Name = x.Name.ToString()
                /*    CreatedBy = x.CreatedBy.ToString(),
                    CreatedOnText = x.CreatedOn.ToString("dd/MM/yyyyy"),
                    ModifiedBy = x.ModifiedBy.ToString(),
                    ModifiedOnText = x.ModifiedOn.ToString("dd/MM/yyyyy")*/
                }).ToList();

            return new ListOutputModel
            {
                Data = data,
                RecordsTotal = recordsTotal
            };
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _uow.JobCategoryRepository.Delete(id);
            
            return await _uow.Save();
        }

        public async Task<JobCategoryAddEditModel> Get(int id)
        {
            var jobs = await _uow.JobCategoryRepository.Get(id);
            var result = new JobCategoryAddEditModel
            {
                Id = jobs.Id,
                Name = jobs.Name,
                //CreatedBy = jobs.CreatedBy,
                //CreatedOn = jobs.CreatedOn,
                //ModifiedBy = jobs.ModifiedBy,
                //ModifiedOn = jobs.ModifiedOn
            };

            return result;
        }

        public async Task<bool> Add(JobCategoryAddEditModel model)
        {
            var jobs = new JobCategory
            {
                Name = model.Name,
                CreatedBy = model.CreatedBy,
                CreatedOn = model.CreatedOn,
                ModifiedBy = model.ModifiedBy,
                ModifiedOn = model.ModifiedOn
            };
            var result = await _uow.JobCategoryRepository.Add(jobs);
            return result;
        }

        public async Task<bool> Update(JobCategoryAddEditModel model)
        {
            var jobs = new JobCategory
            {
                Id = model.Id,
                Name = model.Name,
                CreatedBy = model.CreatedBy,
                CreatedOn = model.CreatedOn,
                ModifiedBy = model.ModifiedBy,
                ModifiedOn = model.ModifiedOn
            };
            var result = await _uow.JobCategoryRepository.Update(jobs);
            return result;
        }

        public async Task<bool> Save(JobCategoryAddEditModel model)
        {
            JobCategory job;
            var task = "Add";
            if (model.Id == 0)
            {
                job = new JobCategory();
                await _uow.JobCategoryRepository.Add(job);
            }
            else
            {
                job = await _uow.JobCategoryRepository.Get(model.Id);
                await _uow.JobCategoryRepository.Update(job);
                task = "Update";
            }

            // job.Id = model.Id;
            job.Name = model.Name;
            if (task == "Add")
            {
                job.CreatedBy = model.CreatedOnText;
                job.CreatedOn = DateTime.Now;
            }
            job.ModifiedBy = model.CreatedOnText;
            job.ModifiedOn = DateTime.Now;

            return await _uow.Save();
        }

        public async Task<IEnumerable<LookupModel>> GetLookup()
        {
            var result = await _uow.JobCategoryRepository.Query().Select(x =>
                new LookupModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            return result;
        }
    }
}
