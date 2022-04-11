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
    public interface IScheduleWebinarService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<bool> Save(ScheduleWebinarAddEditModel model);
        Task<ScheduleWebinarAddEditModel> Get(int id);
        Task<bool> Delete(int id);
    }
    public class ScheduleWebinarService : IScheduleWebinarService
    {

        private IUnitOfWork _uow;
        public ScheduleWebinarService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var emp = _uow.ScheduleWebinarRepository.Query();

            if (!string.IsNullOrEmpty(model.Search))
            {
                emp = emp.Where(x => x.Title.ToLower().Contains(model.Search.ToLower())
                         || x.Email.ToLower().Contains(model.Search.ToLower())
                         || x.PresenterEmail.Equals(model.Search)
                         || x.PresenterName.ToLower().Contains(model.Search.ToLower())
                         || x.VirtualLink.ToLower().Contains(model.Search.ToLower())
                         || x.WorkExperience.Equals(model.Search));
            }

            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                emp = emp.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await emp.CountAsync();

            var data = emp.Skip(model.Start).Take(model.Length).AsEnumerable().
                Select(x => new ScheduleWebinarListModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Date = x.Date,
                    Email = x.Email,
                    PresenterName = x.PresenterName,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    PhysicalVirtual = x.PhysicalVirtual,
                }).ToList();

            return new ListOutputModel
            {
                Data = data,
                RecordsTotal = recordsTotal
            };
        }

        public async Task<bool> Save(ScheduleWebinarAddEditModel model)
        {
            ScheduleWebinar webinar;

            if (model.Id == 0)
            {
                    webinar = new ScheduleWebinar();
                    await _uow.ScheduleWebinarRepository.Add(webinar);
            }
            else
            {
                webinar = await _uow.ScheduleWebinarRepository.Get(model.Id);
                await _uow.ScheduleWebinarRepository.Update(webinar);
            }
            webinar.Title = model.Title;
            webinar.UserId = model.UserId;
            webinar.Email = model.Email;
            webinar.PresenterContactNumber = model.PresenterContactNumber;
            webinar.PresenterEmail = model.PresenterEmail;
            webinar.PresenterName = model.PresenterName;
            webinar.StartTime = model.StartTime;
            webinar.EndTime = model.EndTime;
            webinar.Date = model.Date;
            webinar.VirtualLink = model.VirtualLink;
            webinar.PhysicalVirtual = model.PhysicalVirtual;
            webinar.WorkExperience = model.WorkExperience;
            return await _uow.Save();
        }

        public async Task<ScheduleWebinarAddEditModel> Get(int id)
        {
            var webinar = await _uow.ScheduleWebinarRepository.Get(id);
            var result = new ScheduleWebinarAddEditModel
            {
                Id = webinar.Id,
                Title = webinar.Title,
                UserId = webinar.UserId,
                Email = webinar.Email,
                PresenterContactNumber = webinar.PresenterContactNumber,
                PresenterEmail = webinar.PresenterEmail,
                PresenterName = webinar.PresenterName,
                StartTime = Convert.ToDateTime(webinar.StartTime),
                EndTime = Convert.ToDateTime(webinar.EndTime),
                Date = Convert.ToDateTime(webinar.Date),
                VirtualLink = webinar.VirtualLink,
                PhysicalVirtual = webinar.PhysicalVirtual,
                WorkExperience = webinar.WorkExperience,
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _uow.ScheduleWebinarRepository.Delete(id);

            return await _uow.Save();
        }
    }
}
