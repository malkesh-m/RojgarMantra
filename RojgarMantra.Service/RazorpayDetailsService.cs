using RojgarMantra.Core.Models;
using RojgarMantra.Data.Entities;
using RojgarMantra.Repo;
using System.Threading.Tasks;

namespace RojgarMantra.Service
{
    public interface IRazorpayDetailsService
    {
        Task<bool> Delete(int id);
        Task<RazorpayDetailsAddEditModel> Get(int id);
        Task<bool> Save(RazorpayDetailsAddEditModel model);
    }
    public class RazorpayDetailsService : IRazorpayDetailsService
    {
        private readonly IUnitOfWork _uow;

        public RazorpayDetailsService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _uow.RazorpayDetailsRepository.Delete(id);

            return await _uow.Save();
        }

        public async Task<RazorpayDetailsAddEditModel> Get(int id)
        {
            var RazorpayDetails = await _uow.RazorpayDetailsRepository.Get(id);
            var result = new RazorpayDetailsAddEditModel
            {
                Id = RazorpayDetails.Id,
                AccountNo = RazorpayDetails.AccountNo,
                AccountType = RazorpayDetails.AccountType,
                Email = RazorpayDetails.Email,
                ContactNo = RazorpayDetails.ContactNo,
                Password = RazorpayDetails.Password,
                VisibleOnApp = RazorpayDetails.VisibleOnApp,
            };

            return result;
        }


        public async Task<bool> Save(RazorpayDetailsAddEditModel model)
        {
            RazorpayDetails RazorpayDetails;
            //var task = "Add";
            if (model.Id == 0)
            {
                RazorpayDetails = new RazorpayDetails();
                await _uow.RazorpayDetailsRepository.Add(RazorpayDetails);
            }
            else
            {
                RazorpayDetails = await _uow.RazorpayDetailsRepository.Get(model.Id);
                await _uow.RazorpayDetailsRepository.Update(RazorpayDetails);
            }
            RazorpayDetails.AccountNo = model.AccountNo;
            RazorpayDetails.AccountType = model.AccountType;
            RazorpayDetails.Email = model.Email;
            RazorpayDetails.ContactNo = model.ContactNo;
            RazorpayDetails.Password = model.Password;
            RazorpayDetails.VisibleOnApp = model.VisibleOnApp;

            return await _uow.Save();
        }
    }
}
