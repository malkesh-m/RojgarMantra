using RojgarMantra.Core.Models;
using RojgarMantra.Data.Entities;
using RojgarMantra.Repo;
using System.Threading.Tasks;


namespace RojgarMantra.Service
{
    public interface ISMTPDetailsService
    {
        Task<bool> Delete(int id);
        Task<SMTPDetailsAddEditModel> Get(int id);
        Task<bool> Save(SMTPDetailsAddEditModel model);
    }
    public class SMTPDetailsService : ISMTPDetailsService
    {
        private readonly IUnitOfWork _uow;

        public SMTPDetailsService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _uow.SMTPDetailsRepository.Delete(id);

            return await _uow.Save();
        }

        public async Task<SMTPDetailsAddEditModel> Get(int id)
        {
            var SMTPDetails = await _uow.SMTPDetailsRepository.Get(id);
            var result = new SMTPDetailsAddEditModel
            {
                Id = SMTPDetails.Id,
                SenderEmail = SMTPDetails.SenderEmail,
                Host = SMTPDetails.Host,
                Password = SMTPDetails.Password,
                Port = SMTPDetails.Port,
                UserName = SMTPDetails.UserName,
                SenderName = SMTPDetails.SenderName,
            };

            return result;
        }


        public async Task<bool> Save(SMTPDetailsAddEditModel model)
        {
            SMTPDetails SMTPDetails;
            //var task = "Add";
            if (model.Id == 0)
            {
                SMTPDetails = new SMTPDetails();
                await _uow.SMTPDetailsRepository.Add(SMTPDetails);
            }
            else
            {
                SMTPDetails = await _uow.SMTPDetailsRepository.Get(model.Id);
                await _uow.SMTPDetailsRepository.Update(SMTPDetails);
            }
            SMTPDetails.SenderEmail = model.SenderEmail;
            SMTPDetails.Host = model.Host;
            SMTPDetails.Password = model.Password;
            SMTPDetails.Port = model.Port;
            SMTPDetails.UserName = model.UserName;
            SMTPDetails.SenderName = model.SenderName;

            return await _uow.Save();
        }
    }
}
