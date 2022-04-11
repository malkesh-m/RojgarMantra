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
    public interface IDesignationService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<bool> Delete(int id);
        Task<DesignationAddEditModel> Get(int id);
        Task<IEnumerable<LookupModel>> GetLookup();
        Task<bool> Save(DesignationAddEditModel model);
    }
    public class DesignationService : IDesignationService
    {
        private readonly IUnitOfWork _uow;

        public DesignationService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var designations = _uow.DesignationRepository.Query();

            //search job
            if (!string.IsNullOrEmpty(model.Search))
            {
                designations = designations.Where(x => x.Name.ToLower().Contains(model.Search.ToLower()));
            }

            //sort column
            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                designations = designations.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await designations.CountAsync();

            var data = designations.Skip(model.Start).Take(model.Length).AsEnumerable().
                Select(x => new DesignationListModel
                {
                    Id = x.Id,
                    Name = x.Name.ToString()
                }).ToList();

            return new ListOutputModel
            {
                Data = data,
                RecordsTotal = recordsTotal
            };
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _uow.DesignationRepository.Delete(id);

            return await _uow.Save();
        }

        public async Task<DesignationAddEditModel> Get(int id)
        {
            var jobs = await _uow.DesignationRepository.Get(id);
            var result = new DesignationAddEditModel
            {
                Id = jobs.Id,
                Name = jobs.Name
            };

            return result;
        }

        
        public async Task<bool> Save(DesignationAddEditModel model)
        {
            Designation designation;
            if (model.Id == 0)
            {
                designation = new Designation();
                await _uow.DesignationRepository.Add(designation);
            }
            else
            {
                designation = await _uow.DesignationRepository.Get(model.Id);
                await _uow.DesignationRepository.Update(designation);
            }

            designation.Name = model.Name;
            return await _uow.Save();
        }

        public async Task<IEnumerable<LookupModel>> GetLookup()
        {
            var result = await _uow.DesignationRepository.Query().Select(x =>
                new LookupModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            return result;
        }
    }
}
