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
    public interface ISMSHistoryService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<bool> Delete(int id);
        Task<SMSHistoryAddEditModel> Get(int id);
        Task<bool> Save(SMSHistoryAddEditModel model);
    }
    public class SMSHistoryService : ISMSHistoryService
    {
        private readonly IUnitOfWork _uow;

        public SMSHistoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var SMSHistorys = _uow.SMSHistoryRepository.Query();

            //search job
            if (!string.IsNullOrEmpty(model.Search))
            {
                SMSHistorys = SMSHistorys.Where(x => x.DateTime.Equals(model.Search.ToLower())
                    || x.MobileNo.Equals(model.Search.ToLower())
                    || x.TypeOfSMS.ToLower().Contains(model.Search.ToLower()));
            }

            //sort column
            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                SMSHistorys = SMSHistorys.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await SMSHistorys.CountAsync();

            var data = SMSHistorys.Skip(model.Start).Take(model.Length).AsEnumerable().
                Select(x => new SMSHistoryListModel
                {
                    Id = x.Id,
                    TypeOfSMS = x.TypeOfSMS,
                    MobileNo = x.MobileNo,
                    DateTime = x.DateTime
                }).ToList();

            return new ListOutputModel
            {
                Data = data,
                RecordsTotal = recordsTotal
            };
        }
        public async Task<bool> Delete(int id)
        {
            var result = await _uow.SMSHistoryRepository.Delete(id);

            return await _uow.Save();
        }

        public async Task<SMSHistoryAddEditModel> Get(int id)
        {
            var SMSHistory = await _uow.SMSHistoryRepository.Get(id);
            var result = new SMSHistoryAddEditModel
            {
                Id = SMSHistory.Id,
               MobileNo = SMSHistory.MobileNo,
               TypeOfSMS = SMSHistory.TypeOfSMS,
               DateTime = SMSHistory.DateTime,
            };

            return result;
        }


        public async Task<bool> Save(SMSHistoryAddEditModel model)
        {
            SMSHistory SMSHistory;
            //var task = "Add";
            if (model.Id == 0)
            {
                SMSHistory = new SMSHistory();
                await _uow.SMSHistoryRepository.Add(SMSHistory);
            }
            else
            {
                SMSHistory = await _uow.SMSHistoryRepository.Get(model.Id);
                await _uow.SMSHistoryRepository.Update(SMSHistory);
            }
            SMSHistory.MobileNo = model.MobileNo;
            SMSHistory.TypeOfSMS = model.TypeOfSMS;
            SMSHistory.DateTime = model.DateTime;

            return await _uow.Save();
        }
    }
}
