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
    public interface ICityService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<bool> Delete(int id);
        Task<CityAddEditModel> Get(int id);
        Task<bool> Save(CityAddEditModel model);
        Task<IEnumerable<SelectListItem>> GetLookupCity();
    }
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _uow;

        public CityService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var Citys = _uow.CityRepository.Query();

            //search job
            if (!string.IsNullOrEmpty(model.Search))
            {
                Citys = Citys.Where(x => x.Name.ToLower().Contains(model.Search.ToLower()));
            }

            //sort column
            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                Citys = Citys.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await Citys.CountAsync();

            var data = Citys.Skip(model.Start).Take(model.Length).AsEnumerable().
                Select(x => new CityListModel
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
            var result = await _uow.CityRepository.Delete(id);

            return await _uow.Save();
        }

        public async Task<CityAddEditModel> Get(int id)
        {
            var City = await _uow.CityRepository.Get(id);
            var result = new CityAddEditModel
            {
                Id = City.Id,
                Name = City.Name,
                District = City.DistrictId.ToString()

                //CreatedBy = jobs.CreatedBy,
                //CreatedOn = jobs.CreatedOn,
                //ModifiedBy = jobs.ModifiedBy,
                //ModifiedOn = jobs.ModifiedOn
            };

            return result;
        }


        public async Task<bool> Save(CityAddEditModel model)
        {
            City City;
            //var task = "Add";
            if (model.Id == 0)
            {
                City = new City();
                await _uow.CityRepository.Add(City);
            }
            else
            {
                City = await _uow.CityRepository.Get(model.Id);
                await _uow.CityRepository.Update(City);
                //  task = "Update";
            }

            City.Name = model.Name;
            City.DistrictId = Convert.ToInt32(model.District);
            /* if (task == "Add")
             {
                 job.CreatedBy = model.CreatedOnText;
                 job.CreatedOn = DateTime.Now;
             }
             job.ModifiedBy = model.CreatedOnText;
             job.ModifiedOn = DateTime.Now;*/

            return await _uow.Save();
        }
        public async Task<IEnumerable<SelectListItem>> GetLookupCity()
        {
            var result = await _uow.CityRepository.Query().Select(x =>
                new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToListAsync();

            return result;
        }
    }
}
