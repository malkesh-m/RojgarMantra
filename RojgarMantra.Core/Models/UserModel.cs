using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Core.Models
{
    public class UserListModel
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string MarriedStatus { get; set; }
        [Required]
        [MaxLength(50)]
        public string Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        [MaxLength(100)]
        public string PhysicallyChallenged { get; set; }
        [Required]
        public double AlternateContactNumber { get; set; }

        public double ContactNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string Country { get; set; }
        [Required]
        [MaxLength(100)]
        public string State { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        [MaxLength(200)]
        public string PermanentLocation { get; set; }
        [Required]
        [MaxLength(200)]
        public string PrefferredLocation { get; set; }
        [Required]
        [MaxLength(200)]
        public string CurrentAddress { get; set; }
        [MaxLength(100)]
        public string CompanyName { get; set; }
        [MaxLength(100)]
        public string Role { get; set; }
        [Required]
        [MaxLength(100)]
        public string Designation { get; set; }
        [MaxLength(100)]
        public string TotalExperience { get; set; }
        [Required]
        [MaxLength(100)]
        public string Skills { get; set; }
        [MaxLength(100)]
        public string CurrentCTCLac { get; set; }
        [MaxLength(100)]
        public String CurrentCTCThousand { get; set; }
        [MaxLength(100)]
        public String ExpectedCurrentCTCThousand { get; set; }
        [MaxLength(100)]
        public string ExpectedCurrentCTCLac { get; set; }
        [MaxLength(100)]
        public string NegotiableExpectedCTC { get; set; }
        [MaxLength(100)]
        public string NoticePeriod { get; set; }
        [MaxLength(100)]
        public string NegotiablePeriod { get; set; }
        [MaxLength(100)]
        public string PrevCompanyName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime From { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime To { get; set; }
        public int Experience { get; set; }
        [Required]
        public int SSCMarks { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        public DateTime SSCCompletionYear { get; set; }
        [Required]
        public int HSCMarks { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        public DateTime HSCCompletionYear { get; set; }
        [Required]
        [MaxLength(100)]
        public string DegreeName { get; set; }
        [Required]
        public int GraduationMarks { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        public DateTime GraduationCompletionYear { get; set; }
        [Required]
        [MaxLength(200)]
        public string GraduationCompletionInstituteUniversity { get; set; }
        [Required]
        [MaxLength(100)]
        public string PostDegreeName { get; set; }
        [Required]
        public int PostGraduationMarks { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        public DateTime PostGraduationCompletionYear { get; set; }
        [Required]
        [MaxLength(200)]
        public string PostGraduationCompletionInstituteUniversity { get; set; }
        [MaxLength(100)]
        public string CourseName { get; set; }
        [MaxLength(100)]
        public string CourseCompletionDuration { get; set; }
        [MaxLength(100)]
        public String SelectLanguage { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Speak { get; set; }
        public string Resume { get; set; }
    }

    public class UserAddEditModel
    {
        public string Id { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage ="First name required")]
        [Display(Name = "FirstName*")]
        public string FirstName { get; set; }
        [MaxLength(100)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [MaxLength(100)]
        [Display(Name = "Last Name*")]
        [Required(ErrorMessage = "Last name required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        [MaxLength(100)]
        public string State { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(200)]
        [Display(Name = "Permanent Location")]
        public string PermanentLocation { get; set; }
        [MaxLength(200)]
        [Display(Name = "Current Address")]
        public string CurrentAddress { get; set; }
        [MaxLength(100)]
        public string Role { get; set; }
        [MaxLength(100)]
        public string Designation { get; set; }
        [Display(Name = "Contact Number")]
        public double? ContactNumber { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}
