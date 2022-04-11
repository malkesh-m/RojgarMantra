
using RojgarMantra.Data;
using RojgarMantra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Repo
{
    public interface IUnitOfWork
    {
        ApplicationDbContext DbContext { get; }
   


        Task<bool> Save();
        IBaseRepository<ApplicationUser> UserRepository { get; }
        IBaseRepository<JobCategory> JobCategoryRepository { get; }
        IBaseRepository<UserJobSeeker> UserJobSeekerRepository { get; }
        IBaseRepository<UserEmployer> UserEmployerRepository { get; }
        IBaseRepository<UserTrainingInstitute> UserTrainingInstituteRepository { get; }
        IBaseRepository<Designation> DesignationRepository { get; }
        IBaseRepository<SelectionProcess> SelectionProcessRepository { get; }
        IBaseRepository<Role> RoleRepository { get; }
        IBaseRepository<Degree> DegreeRepository { get; }
        IBaseRepository<PlacementDrive> PlacementDriveRepository { get; }
        IBaseRepository<JobAlertDetails> JobAlertDetailsRepository { get; }
        IBaseRepository<JobDetails> JobDetailsRepository { get; }
        IBaseRepository<ScheduleWebinar> ScheduleWebinarRepository { get; }
        IBaseRepository<State> StateRepository { get; }
        IBaseRepository<Country> CountryRepository { get; }
        IBaseRepository<District> DistrictRepository { get; }
        IBaseRepository<City> CityRepository { get; }
        IBaseRepository<SMSDetails> SMSDetailsRepository { get; }
        IBaseRepository<SMSHistory> SMSHistoryRepository { get; }
        IBaseRepository<SMTPDetails> SMTPDetailsRepository { get; }
        IBaseRepository<RazorpayDetails> RazorpayDetailsRepository { get; }
        IBaseRepository<TemplateDetails> TemplateDetailsRepository { get; }


        /* IBaseRepository<BloodDonor> BloodDonorRepository { get; }
         IBaseRepository<Item> ItemRepository { get; }
         IBaseRepository<Supplier> SupplierRepository { get; }
         IBaseRepository<Order> OrderRepository { get; }
         IBaseRepository<OrderDetail> OrderDetailRepository { get; }
 */
    }
}
