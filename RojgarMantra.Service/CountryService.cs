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
    public interface ICountryService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<bool> Delete(int id);
        Task<CountryAddEditModel> Get(int id);
        Task<bool> Save(CountryAddEditModel model);
        Task<IEnumerable<SelectListItem>> GetLookupCountry();
    }
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _uow;

        public CountryService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var Countrys = _uow.CountryRepository.Query();

            //search job
            if (!string.IsNullOrEmpty(model.Search))
            {
                Countrys = Countrys.Where(x => x.Name.ToLower().Contains(model.Search.ToLower()));
            }

            //sort column
            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                Countrys = Countrys.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await Countrys.CountAsync();

            var data = Countrys.Skip(model.Start).Take(model.Length).AsEnumerable().
                Select(x => new CountryListModel
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
            var result = await _uow.CountryRepository.Delete(id);

            return await _uow.Save();
        }

        public async Task<CountryAddEditModel> Get(int id)
        {
            var Country = await _uow.CountryRepository.Get(id);
            var result = new CountryAddEditModel
            {
                Id = Country.Id,
                Name = Country.Name,
                //CreatedBy = jobs.CreatedBy,
                //CreatedOn = jobs.CreatedOn,
                //ModifiedBy = jobs.ModifiedBy,
                //ModifiedOn = jobs.ModifiedOn
            };

            return result;
        }


        public async Task<bool> Save(CountryAddEditModel model)
        {
            Country Country;
            //var task = "Add";
            if (model.Id == 0)
            {
                Country = new Country();
                await _uow.CountryRepository.Add(Country);
            }
            else
            {
                Country = await _uow.CountryRepository.Get(model.Id);
                await _uow.CountryRepository.Update(Country);
                //  task = "Update";
            }

            Country.Name = model.Name;
            /* if (task == "Add")
             {
                 job.CreatedBy = model.CreatedOnText;
                 job.CreatedOn = DateTime.Now;
             }
             job.ModifiedBy = model.CreatedOnText;
             job.ModifiedOn = DateTime.Now;*/

            return await _uow.Save();
        }
        public async Task<IEnumerable<SelectListItem>> GetLookupCountry()
        {
            var result = await _uow.CountryRepository.Query().Select(x =>
                new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToListAsync();

            return result;
        }
    }
}
