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
    public interface IDistrictService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<bool> Delete(int id);
        Task<DistrictAddEditModel> Get(int id);
        Task<bool> Save(DistrictAddEditModel model);
        Task<IEnumerable<SelectListItem>> GetLookupDistrict();
    }
    public class DistrictService : IDistrictService
    {
        private readonly IUnitOfWork _uow;

        public DistrictService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var Districts = _uow.DistrictRepository.Query();

            //search job
            if (!string.IsNullOrEmpty(model.Search))
            {
                Districts = Districts.Where(x => x.Name.ToLower().Contains(model.Search.ToLower()));
            }

            //sort column
            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                Districts = Districts.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await Districts.CountAsync();

            var data = Districts.Skip(model.Start).Take(model.Length).AsEnumerable().
                Select(x => new DistrictListModel
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
            var result = await _uow.DistrictRepository.Delete(id);

            return await _uow.Save();
        }

        public async Task<DistrictAddEditModel> Get(int id)
        {
            var District = await _uow.DistrictRepository.Get(id);
            var result = new DistrictAddEditModel
            {
                Id = District.Id,
                Name = District.Name,
                State = Convert.ToString(District.StateId),
                //CreatedBy = jobs.CreatedBy,
                //CreatedOn = jobs.CreatedOn,
                //ModifiedBy = jobs.ModifiedBy,
                //ModifiedOn = jobs.ModifiedOn
            };

            return result;
        }


        public async Task<bool> Save(DistrictAddEditModel model)
        {
            District District;
            //var task = "Add";
            if (model.Id == 0)
            {
                District = new District();
                await _uow.DistrictRepository.Add(District);
            }
            else
            {
                District = await _uow.DistrictRepository.Get(model.Id);
                await _uow.DistrictRepository.Update(District);
                //  task = "Update";
            }

            District.Name = model.Name;
            District.StateId = Convert.ToInt32(model.State);
            /* if (task == "Add")
             {
                 job.CreatedBy = model.CreatedOnText;
                 job.CreatedOn = DateTime.Now;
             }
             job.ModifiedBy = model.CreatedOnText;
             job.ModifiedOn = DateTime.Now;*/

            return await _uow.Save();
        }
        public async Task<IEnumerable<SelectListItem>> GetLookupDistrict()
        {
            var result = await _uow.DistrictRepository.Query().Select(x =>
                new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToListAsync();

            return result;
        }
    }
}
