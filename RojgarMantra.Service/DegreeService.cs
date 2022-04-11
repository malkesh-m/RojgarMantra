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

namespace RojgarMantra.Service
{
    public interface IDegreeService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<bool> Delete(int id);
        Task<DegreeAddEditModel> Get(int id);
        Task<IEnumerable<LookupModel>> GetLookup();
        Task<IEnumerable<LookupModel>> GetLookupPost();
        Task<bool> Save(DegreeAddEditModel model);
        Task<IEnumerable<LookupModel>> GetLookupAll();
    }
    public class DegreeService : IDegreeService
    {
        private readonly IUnitOfWork _uow;

        public DegreeService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var Degrees = _uow.DegreeRepository.Query();

            //search job
            if (!string.IsNullOrEmpty(model.Search))
            {
                Degrees = Degrees.Where(x => x.Name.ToLower().Contains(model.Search.ToLower()));
            }

            //sort column
            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                Degrees = Degrees.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await Degrees.CountAsync();

            var data = Degrees.Skip(model.Start).Take(model.Length).AsEnumerable().
                Select(x => new DegreeListModel
                {
                    Id = x.Id,
                    Name = x.Name.ToString()

                    /* CreatedBy = x.CreatedBy.ToString(),
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
            var result = await _uow.DegreeRepository.Delete(id);

            return await _uow.Save();
        }

        public async Task<DegreeAddEditModel> Get(int id)
        {
            var degree = await _uow.DegreeRepository.Get(id);
            var result = new DegreeAddEditModel
            {
                Id = degree.Id,
                Name = degree.Name,
                IsPostGraduationCourseOrDegree = degree.IsPostGraduationCourseOrDegree,
            //CreatedBy = jobs.CreatedBy,
            //CreatedOn = jobs.CreatedOn,
            //ModifiedBy = jobs.ModifiedBy,
            //ModifiedOn = jobs.ModifiedOn
        };

            return result;
        }


        public async Task<bool> Save(DegreeAddEditModel model)
        {
            Degree Degree;
            //var task = "Add";
            if (model.Id == 0)
            {
                Degree = new Degree();
                await _uow.DegreeRepository.Add(Degree);
            }
            else
            {
                Degree = await _uow.DegreeRepository.Get(model.Id);
                await _uow.DegreeRepository.Update(Degree);
                //  task = "Update";
            }

            Degree.Name = model.Name;
            Degree.IsPostGraduationCourseOrDegree = model.IsPostGraduationCourseOrDegree;
            /* if (task == "Add")
             {
                 job.CreatedBy = model.CreatedOnText;
                 job.CreatedOn = DateTime.Now;
             }
             job.ModifiedBy = model.CreatedOnText;
             job.ModifiedOn = DateTime.Now;*/

            return await _uow.Save();
        }
        public async Task<IEnumerable<LookupModel>> GetLookupAll()
        {
            var result = await _uow.DegreeRepository.Query().Select(x =>
                new LookupModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            return result;
        }
        public async Task<IEnumerable<LookupModel>> GetLookup()
        {
            var result = await _uow.DegreeRepository.Query().Where(x => x.IsPostGraduationCourseOrDegree == false).Select(x =>
                new LookupModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            return result;
        }
        public async Task<IEnumerable<LookupModel>> GetLookupPost()
        {
            var result = await _uow.DegreeRepository.Query().Where(x => x.IsPostGraduationCourseOrDegree == true).Select(x =>
                new LookupModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            return result;
        }
    }
}
