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
using System.Web.Mvc;

namespace RojgarMantra.Service
{
    public interface ITemplateDetailsService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<bool> Delete(int id);
        Task<TemplateDetailsAddEditModel> Get(int id);
        Task<bool> Save(TemplateDetailsAddEditModel model);
        Task<IEnumerable<SelectListItem>> GetLookupTemplateDetails();
    }
    public class TemplateDetailsService : ITemplateDetailsService
    {
        private readonly IUnitOfWork _uow;

        public TemplateDetailsService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var TemplateDetailss = _uow.TemplateDetailsRepository.Query();

            //search job
            if (!string.IsNullOrEmpty(model.Search))
            {
                TemplateDetailss = TemplateDetailss.Where(x => x.Title.ToLower().Contains(model.Search.ToLower())
                    || x.Type.ToLower().Contains(model.Search.ToLower())
                    || x.Subject.ToLower().Contains(model.Search.ToLower())
                    || x.Body.ToLower().Contains(model.Search.ToLower()));
            }

            //sort column
            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                TemplateDetailss = TemplateDetailss.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await TemplateDetailss.CountAsync();

            var data = TemplateDetailss.Skip(model.Start).Take(model.Length).AsEnumerable().
                Select(x => new TemplateDetailsListModel
                {
                    Id = x.Id,
                    Body = x.Body,
                    Subject = x.Subject,
                    Type = x.Type,
                    Title = x.Title
                }).ToList();

            return new ListOutputModel
            {
                Data = data,
                RecordsTotal = recordsTotal
            };
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _uow.TemplateDetailsRepository.Delete(id);

            return await _uow.Save();
        }

        public async Task<TemplateDetailsAddEditModel> Get(int id)
        {
            var TemplateDetails = await _uow.TemplateDetailsRepository.Get(id);
            var result = new TemplateDetailsAddEditModel
            {
                Id = TemplateDetails.Id,
                Body = TemplateDetails.Body,
                Subject = TemplateDetails.Subject,
                Type = TemplateDetails.Type,
                Title = TemplateDetails.Title
            };

            return result;
        }


        public async Task<bool> Save(TemplateDetailsAddEditModel model)
        {
            TemplateDetails TemplateDetails;
            //var task = "Add";
            if (model.Id == 0)
            {
                TemplateDetails = new TemplateDetails();
                await _uow.TemplateDetailsRepository.Add(TemplateDetails);
            }
            else
            {
                TemplateDetails = await _uow.TemplateDetailsRepository.Get(model.Id);
                await _uow.TemplateDetailsRepository.Update(TemplateDetails);
            }
            TemplateDetails.Body = model.Body;
            TemplateDetails.Subject = model.Subject;
            TemplateDetails.Type = model.Type;
            TemplateDetails.Title = model.Title;

            return await _uow.Save();
        }
        public async Task<IEnumerable<SelectListItem>> GetLookupTemplateDetails()
        {
            var result = await _uow.TemplateDetailsRepository.Query().Select(x =>
                new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Title
                }).ToListAsync();

            return result;
        }
    }
}
