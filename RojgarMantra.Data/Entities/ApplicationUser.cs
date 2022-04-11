using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        //[MaxLength(200)]
        //override public string UserName { get; set; }
        //[Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        //[Required]
        //[MaxLength(50)]
        //public string MarriedStatus { get; set; }
        //[Required]
        //[MaxLength(50)]
        //public string Gender { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime DateOfBirth { get; set; }
        //[MaxLength(100)]
        //public string PhysicallyChallenged { get; set; }
        //[Required]
        //public double AlternateContactNumber { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        [MaxLength(100)]
        public string State { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(200)]
        public string PermanentLocation { get; set; }
        //[Required]
        //[MaxLength(200)]
        //public string PrefferredLocation { get; set; }
        [MaxLength(200)]
        public string CurrentAddress { get; set; }
        //[MaxLength(100)]
        //public string CompanyName { get; set; }
/*        public int Users_RoleId { get; set; }
        public virtual Role Users_Role { get; set; }
        public int Desig_Id { get; set; }
        public virtual Designation Desig { get; set; }*/
        [MaxLength(100)]
        public string Status { get; set; }
        //[MaxLength(100)]
        //public string TotalExperience { get; set; }
        //[Required]
        //[MaxLength(100)]
        //public string Skills { get; set; }
        //[MaxLength(100)]
        //public string CurrentCTCLac { get; set; }
        //[MaxLength(100)]
        //public String CurrentCTCThousand { get; set; }
        //[MaxLength(100)]
        //public String ExpectedCurrentCTCThousand { get; set; }
        //[MaxLength(100)]
        //public string ExpectedCurrentCTCLac { get; set; }
        //[MaxLength(100)]
        //public string NegotiableExpectedCTC { get; set; }
        //[MaxLength(100)]
        //public string NoticePeriod { get; set; }
        //[MaxLength(100)]
        //public string NegotiablePeriod { get; set; }
        //[MaxLength(100)]
        //public string PrevCompanyName { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime From { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime To { get; set; }
        //public int Experience { get; set; }
        //[Required]
        //public int SSCMarks { get; set; }
        //[Required]
        //[DisplayFormat(DataFormatString = "{0:yyyy}")]
        //public DateTime SSCCompletionYear { get; set; }
        //[Required]
        //public int HSCMarks { get; set; }
        //[Required]
        //[DisplayFormat(DataFormatString = "{0:yyyy}")]
        //public DateTime HSCCompletionYear { get; set; }
        //[Required]
        //[MaxLength(100)]
        //public string DegreeName { get; set; }
        //[Required]
        //public int GraduationMarks { get; set; }
        //[Required]
        //[DisplayFormat(DataFormatString = "{0:yyyy}")]
        //public DateTime GraduationCompletionYear { get; set; }
        //[Required]
        //[MaxLength(200)]
        //public string GraduationCompletionInstituteUniversity { get; set; }
        //[Required]
        //[MaxLength(100)]
        //public string PostDegreeName { get; set; }
        //[Required]
        //public int PostGraduationMarks { get; set; }
        //[Required]
        //[DisplayFormat(DataFormatString = "{0:yyyy}")]
        //public DateTime PostGraduationCompletionYear { get; set; }
        //[Required]
        //[MaxLength(200)]
        //public string PostGraduationCompletionInstituteUniversity { get; set; }
        //[MaxLength(100)]
        //public string CourseName { get; set; }
        //[MaxLength(100)]
        //public string CourseCompletionDuration { get; set; }
        //[MaxLength(100)]
        //public String SelectLanguage { get; set; }
        //public bool Read { get; set; }
        //public bool Write { get; set; }
        //public bool Speak { get; set; }
        //public string Resume { get; set; }

        //public virtual UserJobSeeker UserJobSeeker { get; set; }
        //public virtual UserEmployer UserEmployer { get; set; }

        /*public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }*/
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public class ApplicationUsersmtp : IdentityUser
        {
            //[MaxLength(200)]
            //override public string UserName { get; set; }
            //[Required]
            [MaxLength(100)]
            public string Host { get; set; }
           
           
            //[Required]
            //[MaxLength(50)]
            //public string MarriedStatus { get; set; }
            //[Required]
            //[MaxLength(50)]
            //public string Gender { get; set; }
            //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            //public DateTime DateOfBirth { get; set; }
            //[MaxLength(100)]
            //public string PhysicallyChallenged { get; set; }
            //[Required]
            //public double AlternateContactNumber { get; set; }
            //[Required]
            //[MaxLength(100)]
            //public string Country { get; set; }
            //[Required]
            //[MaxLength(100)]
            //public string State { get; set; }
            //[Required]
            //[MaxLength(100)]
            //public string City { get; set; }
            //[Required]
            //[MaxLength(200)]
            //public string PermanentLocation { get; set; }
            //[Required]
            //[MaxLength(200)]
            //public string PrefferredLocation { get; set; }
            //[Required]
            //[MaxLength(200)]
            //public string CurrentAddress { get; set; }
            //[MaxLength(100)]
            //public string CompanyName { get; set; }
            //[MaxLength(100)]
            //public string Role { get; set; }
            //[Required]
            //[MaxLength(100)]
            //public string Designation { get; set; }
            //[MaxLength(100)]
            //public string TotalExperience { get; set; }
            //[Required]
            //[MaxLength(100)]
            //public string Skills { get; set; }
            //[MaxLength(100)]
            //public string CurrentCTCLac { get; set; }
            //[MaxLength(100)]
            //public String CurrentCTCThousand { get; set; }
            //[MaxLength(100)]
            //public String ExpectedCurrentCTCThousand { get; set; }
            //[MaxLength(100)]
            //public string ExpectedCurrentCTCLac { get; set; }
            //[MaxLength(100)]
            //public string NegotiableExpectedCTC { get; set; }
            //[MaxLength(100)]
            //public string NoticePeriod { get; set; }
            //[MaxLength(100)]
            //public string NegotiablePeriod { get; set; }
            //[MaxLength(100)]
            //public string PrevCompanyName { get; set; }
            //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            //public DateTime From { get; set; }
            //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            //public DateTime To { get; set; }
            //public int Experience { get; set; }
            //[Required]
            //public int SSCMarks { get; set; }
            //[Required]
            //[DisplayFormat(DataFormatString = "{0:yyyy}")]
            //public DateTime SSCCompletionYear { get; set; }
            //[Required]
            //public int HSCMarks { get; set; }
            //[Required]
            //[DisplayFormat(DataFormatString = "{0:yyyy}")]
            //public DateTime HSCCompletionYear { get; set; }
            //[Required]
            //[MaxLength(100)]
            //public string DegreeName { get; set; }
            //[Required]
            //public int GraduationMarks { get; set; }
            //[Required]
            //[DisplayFormat(DataFormatString = "{0:yyyy}")]
            //public DateTime GraduationCompletionYear { get; set; }
            //[Required]
            //[MaxLength(200)]
            //public string GraduationCompletionInstituteUniversity { get; set; }
            //[Required]
            //[MaxLength(100)]
            //public string PostDegreeName { get; set; }
            //[Required]
            //public int PostGraduationMarks { get; set; }
            //[Required]
            //[DisplayFormat(DataFormatString = "{0:yyyy}")]
            //public DateTime PostGraduationCompletionYear { get; set; }
            //[Required]
            //[MaxLength(200)]
            //public string PostGraduationCompletionInstituteUniversity { get; set; }
            //[MaxLength(100)]
            //public string CourseName { get; set; }
            //[MaxLength(100)]
            //public string CourseCompletionDuration { get; set; }
            //[MaxLength(100)]
            //public String SelectLanguage { get; set; }
            //public bool Read { get; set; }
            //public bool Write { get; set; }
            //public bool Speak { get; set; }
            //public string Resume { get; set; }

            //public virtual UserJobSeeker UserJobSeeker { get; set; }
            //public virtual UserEmployer UserEmployer { get; set; }

            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUsersmtp> manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                return userIdentity;
            }
        }
    }
}
