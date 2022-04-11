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
    public interface ISMSDetailsService
    {
        Task<bool> Delete(int id);
        Task<SMSDetailsAddEditModel> Get(int id);
        Task<bool> Save(SMSDetailsAddEditModel model);
    }
    public class SMSDetailsService : ISMSDetailsService
    {
        private readonly IUnitOfWork _uow;

        public SMSDetailsService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _uow.SMSDetailsRepository.Delete(id);

            return await _uow.Save();
        }

        public async Task<SMSDetailsAddEditModel> Get(int id)
        {
            var SMSDetails = await _uow.SMSDetailsRepository.Get(id);
            var result = new SMSDetailsAddEditModel
            {
                Id = SMSDetails.Id,
                UserName = SMSDetails.UserName,
                SenderName = SMSDetails.SenderName,
                Url = SMSDetails.Url,
                Credit = SMSDetails.Credit,
                Password = SMSDetails.Password
            };

            return result;
        }


        public async Task<bool> Save(SMSDetailsAddEditModel model)
        {
            SMSDetails SMSDetails;
            //var task = "Add";
            if (model.Id == 0)
            {
                SMSDetails = new SMSDetails();
                await _uow.SMSDetailsRepository.Add(SMSDetails);
            }
            else
            {
                SMSDetails = await _uow.SMSDetailsRepository.Get(model.Id);
                await _uow.SMSDetailsRepository.Update(SMSDetails);
            }
            SMSDetails.UserName = model.UserName;
            SMSDetails.SenderName = model.SenderName;
            SMSDetails.Url = model.Url;
            SMSDetails.Credit = model.Credit;
            SMSDetails.Password = model.Password;

            return await _uow.Save();
        }
    }
}
