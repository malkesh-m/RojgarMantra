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
using System.Web.Mvc;

namespace RojgarMantra.Service
{
    public interface IStateService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<bool> Delete(int id);
        Task<StateAddEditModel> Get(int id);
        Task<bool> Save(StateAddEditModel model);
        Task<IEnumerable<SelectListItem>> GetLookupState();
    }
    public class StateService : IStateService
    {
        private readonly IUnitOfWork _uow;

        public StateService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var States = _uow.StateRepository.Query();

            //search job
            if (!string.IsNullOrEmpty(model.Search))
            {
                States = States.Where(x => x.Name.ToLower().Contains(model.Search.ToLower()));
            }

            //sort column
            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                States = States.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await States.CountAsync();

            var data = States.Skip(model.Start).Take(model.Length).AsEnumerable().
                Select(x => new StateListModel
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
            var result = await _uow.StateRepository.Delete(id);

            return await _uow.Save();
        }

        public async Task<StateAddEditModel> Get(int id)
        {
            var State = await _uow.StateRepository.Get(id);
            var result = new StateAddEditModel
            {
                Id = State.Id,
                Name = State.Name,
                Country = Convert.ToString(State.CountryId),
                //CreatedBy = jobs.CreatedBy,
                //CreatedOn = jobs.CreatedOn,
                //ModifiedBy = jobs.ModifiedBy,
                //ModifiedOn = jobs.ModifiedOn
            };

            return result;
        }


        public async Task<bool> Save(StateAddEditModel model)
        {
            State State;
            //var task = "Add";
            if (model.Id == 0)
            {
                State = new State();
                await _uow.StateRepository.Add(State);
            }
            else
            {
                State = await _uow.StateRepository.Get(model.Id);
                await _uow.StateRepository.Update(State);
                //  task = "Update";
            }

            State.Name = model.Name;
            State.CountryId =Convert.ToInt32( model.Country);
            /* if (task == "Add")
             {
                 job.CreatedBy = model.CreatedOnText;
                 job.CreatedOn = DateTime.Now;
             }
             job.ModifiedBy = model.CreatedOnText;
             job.ModifiedOn = DateTime.Now;*/

            return await _uow.Save();
        }
       /* public async Task<IEnumerable<LookupModel>> GetLookupState()
        {
            var result = await _uow.StateRepository.Query().Select(x =>
                new LookupModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            return result;
        }*/

        public async Task<IEnumerable<SelectListItem>> GetLookupState()
        {
            var result = await _uow.StateRepository.Query().Select(x =>
                new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToListAsync();

            return result;
        }
    }
}
