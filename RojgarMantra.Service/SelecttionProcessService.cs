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
    public interface ISelectionProcessService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<bool> Delete(int id);
        Task<SelectionProcessAddEditModel> Get(int id);
        Task<IEnumerable<LookupModel>> GetLookup();
        Task<bool> Save(SelectionProcessAddEditModel model);
    }
    public class SelectionProcessService : ISelectionProcessService
    {
        private readonly IUnitOfWork _uow;

        public SelectionProcessService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var SelectionProcesss = _uow.SelectionProcessRepository.Query();

            //search job
            if (!string.IsNullOrEmpty(model.Search))
            {
                SelectionProcesss = SelectionProcesss.Where(x => x.Name.ToLower().Contains(model.Search.ToLower()));
            }

            //sort column
            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                SelectionProcesss = SelectionProcesss.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await SelectionProcesss.CountAsync();

            var data = SelectionProcesss.Skip(model.Start).Take(model.Length).AsEnumerable().
                Select(x => new SelectionProcessListModel
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
            var result = await _uow.SelectionProcessRepository.Delete(id);

            return await _uow.Save();
        }

        public async Task<SelectionProcessAddEditModel> Get(int id)
        {
            var jobs = await _uow.SelectionProcessRepository.Get(id);
            var result = new SelectionProcessAddEditModel
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


        public async Task<bool> Save(SelectionProcessAddEditModel model)
        {
            SelectionProcess SelectionProcess;
            //var task = "Add";
            if (model.Id == 0)
            {
                SelectionProcess = new SelectionProcess();
                await _uow.SelectionProcessRepository.Add(SelectionProcess);
            }
            else
            {
                SelectionProcess = await _uow.SelectionProcessRepository.Get(model.Id);
                await _uow.SelectionProcessRepository.Update(SelectionProcess);
                //  task = "Update";
            }

            SelectionProcess.Name = model.Name;
            /* if (task == "Add")
             {
                 job.CreatedBy = model.CreatedOnText;
                 job.CreatedOn = DateTime.Now;
             }
             job.ModifiedBy = model.CreatedOnText;
             job.ModifiedOn = DateTime.Now;*/

            return await _uow.Save();
        }
        public async Task<IEnumerable<LookupModel>> GetLookup()
        {
            var result = await _uow.SelectionProcessRepository.Query().Select(x =>
                new LookupModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            return result;
        }
    }
}
