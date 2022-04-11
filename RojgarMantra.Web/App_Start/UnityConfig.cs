using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using RojgarMantra.Controllers;
using RojgarMantra.Data;
using RojgarMantra.Data.Entities;
using RojgarMantra.Models;
using RojgarMantra.Repo;
using RojgarMantra.Service;
using System;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;

namespace RojgarMantra
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => System.Web.HttpContext.Current.GetOwinContext().Authentication));
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<UserManager<ApplicationUser>>();
            container.RegisterType<DbContext, ApplicationDbContext>();
          //  container.RegisterType<DbContext, CountryDbContext>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IJobCategoryService, JobCategoryService>();
            container.RegisterType<IUserJobSeekerService, UserJobSeekerService>();
            container.RegisterType<IUserEmployerService, UserEmployerService>();
            container.RegisterType<IComanService, ComanService>();
            container.RegisterType<IUserTrainingInstituteService, UserTrainingInstituteService>();
            container.RegisterType<IDesignationService, DesignationService>();
            container.RegisterType<ISelectionProcessService, SelectionProcessService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IDegreeService, DegreeService>();
            container.RegisterType<IScheduleWebinarService, ScheduleWebinarService>();
            container.RegisterType<IPlacementDriveService, PlacementDriveService>();
            container.RegisterType<IJobAlertDetailsService, JobAlertDetailsService>();
            container.RegisterType<IJobDetailsService, JobDetailsService>();
            container.RegisterType<ICountryService, CountryService>();
            container.RegisterType<IStateService, StateService>();
            container.RegisterType<ICityService, CityService>();
            container.RegisterType<IDistrictService, DistrictService>();
            container.RegisterType<ISMTPDetailsService, SMTPDetailsService>();
            container.RegisterType<ISMSDetailsService, SMSDetailsService>();
            container.RegisterType<ISMSHistoryService, SMSHistoryService>();
            container.RegisterType<IRazorpayDetailsService, RazorpayDetailsService>();
            container.RegisterType<ITemplateDetailsService, TemplateDetailsService>();
           // container.RegisterType<IcountryServices, CountryRepositort>();


            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}