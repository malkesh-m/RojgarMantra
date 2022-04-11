using RojgarMantra.Data;
using RojgarMantra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        IBaseRepository<ApplicationUser> _userRepository;
        IBaseRepository<JobCategory> _jobCategoryRepository;
        IBaseRepository<UserJobSeeker> _userJobSeekerRepository;
        IBaseRepository<UserEmployer> _userEmployerRepository;
        IBaseRepository<UserTrainingInstitute> _userTrainingInstituteRepository;
        IBaseRepository<Designation> _designationRepository;
        IBaseRepository<SelectionProcess> _selectionProcessRepository ;
        IBaseRepository<Role> _roleRepository ;
        IBaseRepository<Degree> _degreeRepository ;
        IBaseRepository<PlacementDrive> _placementDriveRepository ;
        IBaseRepository<JobAlertDetails> _jobAlertDetailsRepository ;
        IBaseRepository<JobDetails> _jobDetailsRepository ;
        IBaseRepository<ScheduleWebinar> _scheduleWebinarRepository ;
        IBaseRepository<Country> _CountryRepository;
        IBaseRepository<State> _StateRepository;
        IBaseRepository<City> _CityRepository;
        IBaseRepository<District> _DistrictRepository;
        IBaseRepository<SMSDetails> _SMSDetailsRepository;
        IBaseRepository<SMSHistory> _SMSHistoryRepository;
        IBaseRepository<SMTPDetails> _SMTPDetailsRepository;
        IBaseRepository<RazorpayDetails> _RazorpayDetailsRepository;
        IBaseRepository<TemplateDetails> _TemplateDetailsRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

       

        public ApplicationDbContext DbContext { get; private set; }

        public async Task<bool> Save()
        {
            try
            {
                int _save = await DbContext.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (System.Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public IBaseRepository<ApplicationUser> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new BaseRepository<ApplicationUser>(DbContext);
                }
                return _userRepository;
            }
        }

        public IBaseRepository<JobCategory> JobCategoryRepository
        {
            get
            {
                if (_jobCategoryRepository == null)
                {
                    _jobCategoryRepository = new BaseRepository<JobCategory>(DbContext);
                }
                return _jobCategoryRepository;
            }
        }

        public IBaseRepository<UserEmployer> UserEmployerRepository
        {
            get
            {
                if(_userEmployerRepository == null)
                {
                    _userEmployerRepository = new BaseRepository<UserEmployer>(DbContext);
                }
                return _userEmployerRepository; 
            }
        }

        public IBaseRepository<UserJobSeeker> UserJobSeekerRepository
        {
            get
            {
                if (_userJobSeekerRepository == null)
                {
                    _userJobSeekerRepository = new BaseRepository<UserJobSeeker>(DbContext);
                }
                return _userJobSeekerRepository;
            }
        }

        public IBaseRepository<UserTrainingInstitute> UserTrainingInstituteRepository
        {
            get
            {
                if(_userTrainingInstituteRepository == null)
                {
                    _userTrainingInstituteRepository = new BaseRepository<UserTrainingInstitute>(DbContext);
                }
                return _userTrainingInstituteRepository;
            }
        }
        public IBaseRepository<Designation> DesignationRepository
        {
            get
            {
                if (_designationRepository == null)
                {
                    _designationRepository = new BaseRepository<Designation>(DbContext);
                }
                return _designationRepository;
            }
        }
        public IBaseRepository<Role> RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new BaseRepository<Role>(DbContext);
                }
                return _roleRepository;
            }
        }
        public IBaseRepository<SelectionProcess> SelectionProcessRepository
        {
            get
            {
                if (_selectionProcessRepository == null)
                {
                    _selectionProcessRepository = new BaseRepository<SelectionProcess>(DbContext);
                }
                return _selectionProcessRepository;
            }
        }
        public IBaseRepository<Degree> DegreeRepository
        {
            get
            {
                if (_degreeRepository == null)
                {
                    _degreeRepository = new BaseRepository<Degree>(DbContext);
                }
                return _degreeRepository;
            }
        }
        public IBaseRepository<PlacementDrive> PlacementDriveRepository
        {
            get
            {
                if (_placementDriveRepository == null)
                {
                    _placementDriveRepository = new BaseRepository<PlacementDrive>(DbContext);
                }
                return _placementDriveRepository;
            }
        }
        public IBaseRepository<JobDetails> JobDetailsRepository
        {
            get
            {
                if (_jobDetailsRepository == null)
                {
                    _jobDetailsRepository = new BaseRepository<JobDetails>(DbContext);
                }
                return _jobDetailsRepository;
            }
        }
        public IBaseRepository<JobAlertDetails> JobAlertDetailsRepository
        {
            get
            {
                if (_jobAlertDetailsRepository == null)
                {
                    _jobAlertDetailsRepository = new BaseRepository<JobAlertDetails>(DbContext);
                }
                return _jobAlertDetailsRepository;
            }
        }
        public IBaseRepository<ScheduleWebinar> ScheduleWebinarRepository
        {
            get
            {
                if (_scheduleWebinarRepository == null)
                {
                    _scheduleWebinarRepository = new BaseRepository<ScheduleWebinar>(DbContext);
                }
                return _scheduleWebinarRepository;
            }
        }

        public IBaseRepository<Country> CountryRepository
        {
            get
            {
                if (_CountryRepository == null)
                {
                    _CountryRepository = new BaseRepository<Country>(DbContext);
                }
                return _CountryRepository;
            }
        }

        public IBaseRepository<State> StateRepository
        {
            get
            {
                if (_StateRepository == null)
                {
                    _StateRepository = new BaseRepository<State>(DbContext);
                }
                return _StateRepository;
            }
        }
        public IBaseRepository<City> CityRepository
        {
            get
            {
                if (_CityRepository == null)
                {
                    _CityRepository = new BaseRepository<City>(DbContext);
                }
                return _CityRepository;
            }
        }
        public IBaseRepository<District> DistrictRepository
        {
            get
            {
                if (_DistrictRepository == null)
                {
                    _DistrictRepository = new BaseRepository<District>(DbContext);
                }
                return _DistrictRepository;
            }
        }
        public IBaseRepository<SMSDetails> SMSDetailsRepository
        {
            get
            {
                if (_SMSDetailsRepository == null)
                {
                    _SMSDetailsRepository = new BaseRepository<SMSDetails>(DbContext);
                }
                return _SMSDetailsRepository;
            }
        }
        public IBaseRepository<SMSHistory> SMSHistoryRepository
        {
            get
            {
                if (_SMSHistoryRepository == null)
                {
                    _SMSHistoryRepository = new BaseRepository<SMSHistory>(DbContext);
                }
                return _SMSHistoryRepository;
            }
        }
        public IBaseRepository<SMTPDetails> SMTPDetailsRepository
        {
            get
            {
                if (_SMTPDetailsRepository == null)
                {
                    _SMTPDetailsRepository = new BaseRepository<SMTPDetails>(DbContext);
                }
                return _SMTPDetailsRepository;
            }
        }
        public IBaseRepository<RazorpayDetails> RazorpayDetailsRepository
        {
            get
            {
                if (_RazorpayDetailsRepository == null)
                {
                    _RazorpayDetailsRepository = new BaseRepository<RazorpayDetails>(DbContext);
                }
                return _RazorpayDetailsRepository;
            }
        }
        public IBaseRepository<TemplateDetails> TemplateDetailsRepository
        {
            get
            {
                if (_TemplateDetailsRepository == null)
                {
                    _TemplateDetailsRepository = new BaseRepository<TemplateDetails>(DbContext);
                }
                return _TemplateDetailsRepository;
            }
        }
    }
}
