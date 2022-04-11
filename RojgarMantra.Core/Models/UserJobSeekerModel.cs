using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RojgarMantra.Core.Models
{
    public class UserJobSeekerListModel
    {
        public int Id { get; set; }
        // public virtual ApplicationUser ApplicationUser { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string MiddleName { get; set; }
        public double ContactNumber { get; set; }
        public string LastName { get; set; }
        public string MarriedStatus { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool PhysicallyChallenged { get; set; }
        public double AlternateContactNumber { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PermanentLocation { get; set; }
        public string PrefferredLocation { get; set; }
        public string CurrentAddress { get; set; }
        public string CompanyName { get; set; }
        public string Role { get; set; }
        public string Designation { get; set; }
        public string TotalExperience { get; set; }
        public string Skills { get; set; }
        public string CurrentCTCLac { get; set; }
        public String CurrentCTCThousand { get; set; }
        public String ExpectedCurrentCTCThousand { get; set; }
        public string ExpectedCurrentCTCLac { get; set; }
        public string NegotiableExpectedCTC { get; set; }
        public string NoticePeriod { get; set; }
        public bool NegotiableNoticePeriod { get; set; }
        public string PrevCompanyName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Experience { get; set; }
        public int SSCMarks { get; set; }
        public string SSCCompletionYear { get; set; }
        public int HSCMarks { get; set; }
        public string HSCCompletionYear { get; set; }
        public string DegreeName { get; set; }
        public int GraduationMarks { get; set; }
        public string GraduationCompletionYear { get; set; }
        public string GraduationCompletionInstituteUniversity { get; set; }
        public string PostDegreeName { get; set; }
        public int PostGraduationMarks { get; set; }
        public string PostGraduationCompletionYear { get; set; }
        public string PostGraduationCompletionInstituteUniversity { get; set; }
        public string CourseName { get; set; }
        public string CourseCompletionDuration { get; set; }
        public String SelectLanguage { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Speak { get; set; }
        public string Resume { get; set; }
    }
    public class UserJobSeekerAddEditModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        [Display(Name = "User Name")]
        [MaxLength(200)]
        public string UserName { get; set; }
        [Display(Name = "First Name*")]
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        [MaxLength(100)]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name*")]
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Display(Name = "Married Status*")]
        [Required]
        [MaxLength(50)]
        public string MarriedStatus { get; set; }
        [Required]
        [MaxLength(50)]
        public string Gender { get; set; }
        [Required(ErrorMessage = "The Date Of Birth* field is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth*")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Physically Challenged")]
        public bool PhysicallyChallenged { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Contact Number* field is required.")]
        [Display(Name = "Contact Number*")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid contact number")]
        public double? ContactNumber { get; set; }
        [Required(ErrorMessage = "The Alternate Contact Number* field is required.")]
        [Display(Name = "Alternate Contact Number*")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid alternate contact number")]
        public double? AlternateContactNumber { get; set; }
        [Display(Name = "Country*")]
        [Required]
        [MaxLength(100)]
        public string Country { get; set; }
        [Display(Name = "State*")]
        [Required]
        [MaxLength(100)]
        public string State { get; set; }
        [Display(Name = "City*")]
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Display(Name = "Permanent Location*")]
        [Required]
        [MaxLength(200)]
        public string PermanentLocation { get; set; }
        [Display(Name = "Prefferred Location*")]
        [Required]
        [MaxLength(200)]
        public string PrefferredLocation { get; set; }
        [Display(Name = "Current Address*")]
        [Required]
        [MaxLength(200)]
        public string CurrentAddress { get; set; }
        [Display(Name = "Company Name")]
        [MaxLength(100)]
        public string CompanyName { get; set; }
        [MaxLength(100)]
        public string Role { get; set; }
        [Display(Name = "Designation*")]
        [Required]
        [MaxLength(100)]
        public string Designation { get; set; }
        [Display(Name = "Total Experience")]
        [MaxLength(100)]
        public string TotalExperience { get; set; }
        [Display(Name = "Skills*")]
        [Required]
        [MaxLength(100)]
        public string Skills { get; set; }
        [Display(Name = "Current CTC Lac")]
        [MaxLength(100)]
        public string CurrentCTCLac { get; set; }
        [Display(Name = "Current CTC Thousand")]
        [MaxLength(100)]
        public String CurrentCTCThousand { get; set; }
        [Display(Name = "Expected Current CTC Thousand")]
        [MaxLength(100)]
        public String ExpectedCurrentCTCThousand { get; set; }
        [Display(Name = "Expected Current CTC Lac")]
        [MaxLength(100)]
        public string ExpectedCurrentCTCLac { get; set; }
        [Display(Name = "Negotiable Expected CTC")]
        [MaxLength(100)]
        public string NegotiableExpectedCTC { get; set; }
        [Display(Name = "Notice Period")]
        [MaxLength(100)]
        public string NoticePeriod { get; set; }
        [Display(Name = "Negotiable Notice Period")]
        public bool NegotiableNoticePeriod { get; set; }
        [Display(Name = "Prev Company Name")]
        [MaxLength(100)]
        public string PrevCompanyName { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
        public int Experience { get; set; }
        [Display(Name = "SSC Marks")]
        [Range(0, 100, ErrorMessage = "Enter Marks between 0 to 100")]
        [Required(ErrorMessage = "The SSC Marks* field is required.")]
        public int? SSCMarks { get; set; }
        [Display(Name = "SSC Completion Year*")]
        [Required]
        public string SSCCompletionYear { get; set; }
        [Display(Name = "HSC Marks*")]
        [Range(0, 100, ErrorMessage = "Enter Marks between 0 to 100")]
        [Required(ErrorMessage = "The HSC Marks* field is required.")]
        public int? HSCMarks { get; set; }
        [Display(Name = "HSC Completion Year*")]
        [Required]
        public string HSCCompletionYear { get; set; }
        [Display(Name = "Degree Name*")]
        [Required]
        [MaxLength(100)]
        public string DegreeName { get; set; }
        [Display(Name = "Graduation Marks*")]
        [Range(0, 100, ErrorMessage = "Enter Marks between 0 to 100")]
        [Required(ErrorMessage = "The Graduation Marks* field is required.")]
        public int? GraduationMarks { get; set; }
        [Display(Name = "Graduation Completion Year*")]
  //      [Range(1, int.MaxValue)]
        [Required]
        public string GraduationCompletionYear { get; set; }
        [Display(Name = "Graduation Completion Institute University*")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [MaxLength(200)]
        public string GraduationCompletionInstituteUniversity { get; set; }
        [Display(Name = "Post Degree Name*")]
        [Required]
        [MaxLength(100)]
        public string PostDegreeName { get; set; }
        [Display(Name = "Post Graduation Marks*")]
        [Range(0, 100, ErrorMessage = "Enter Marks between 0 to 100")]
        [Required(ErrorMessage = "The Post Graduation Marks* field is required.")]
        public int? PostGraduationMarks { get; set; }
        [Display(Name = "Post Graduation Completion Year*")]
        [Required]
        public string PostGraduationCompletionYear { get; set; }
        [Display(Name = "Post Graduation Completion Institute University*")]
        [Required]
        [MaxLength(200)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string PostGraduationCompletionInstituteUniversity { get; set; }
        [Display(Name = "Course Name")]
        [MaxLength(100)]
        public string CourseName { get; set; }
        [Display(Name = "Course Completion Duration")]
        [MaxLength(100)]
        public string CourseCompletionDuration { get; set; }
        [Display(Name = "Select Language")]
        [MaxLength(100)]
        public String SelectLanguage { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Speak { get; set; }

        public HttpPostedFileBase Resume { get; set; }
    }

}
