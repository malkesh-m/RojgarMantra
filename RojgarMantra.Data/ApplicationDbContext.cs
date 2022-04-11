using System.Threading;
using System.Threading.Tasks;
using RojgarMantra.Data.Entities;
using RojgarMantra.Data.Helpers;
using System.Data.Entity;
using MySql.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration;

namespace RojgarMantra.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbConnectionString")
        {
            
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<IdentityRole>()
                .Property(p => p.Name)
                .HasMaxLength(200);

          

            modelBuilder
              .Properties()
              .Where(p => p.PropertyType == typeof(string) &&
                          !p.Name.Contains("Id") &&
                          !p.Name.Contains("Provider"))
              .Configure(p => p.HasMaxLength(200));
            modelBuilder.Entity<ApplicationUser>().Property(u => u.UserName).HasMaxLength(200).IsUnicode(false);
            modelBuilder.Entity<ApplicationUser>().Property(u => u.Email).IsUnicode(false);
            modelBuilder.Entity<IdentityRole>().Property(r => r.Name).HasMaxLength(255);

           /* modelBuilder.Entity<ApplicationUser>()
           .HasOptional(m => m.UserJobSeeker)
           .WithRequired(m => m.ApplicationUser)
           .Map(p => p.MapKey("UserId"));
*/
           /* modelBuilder.Entity<ApplicationUser>()
           .HasOptional(m => m.UserEmployer)
           .WithRequired(m => m.ApplicationUser)
           .Map(p => p.MapKey("UserId"));*/
        }
      public DbSet<JobCategory> JobCategories { get; set; }

        public DbSet<UserEmployer> UserEmployers { get; set; }
        public DbSet<UserJobSeeker> UserJobSeekers { get; set; }
        public DbSet<UserTrainingInstitute> UserTrainingInstitutes { get; set; }
        public DbSet<ScheduleWebinar> ScheduleWebinars { get; set; }
        public DbSet<JobAlertDetails> JobAlertDetails { get; set; }
        public DbSet<JobDetails> JobDetails { get; set; }
        public DbSet<PlacementDrive> PlacementDrives { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<SelectionProcess> SelectionProcesses { get; set; }
        public DbSet<ExceptionLogger> ExceptionLoggers { get; set; }
        public DbSet<SMSDetails> SMSDetails { get; set; }
        public DbSet<SMTPDetails> SMTPDetails { get; set; }
        public DbSet<SMSHistory> SMSHistories { get; set; }
        public DbSet<RazorpayDetails> RazorpayDetails { get; set; }
        public DbSet<TemplateDetails> TemplateDetails { get; set; }
    }
}