using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Core.Models
{
    public class JobDetailsListModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public double PersonalContactNumber { get; set; }
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public string JobType { get; set; }
        public DateTime? JobStartDate { get; set; }
        public string JobTitle { get; set; }
        public decimal MinWorkExperience { get; set; }
        public decimal MaxWorkExperience { get; set; }
        public decimal MinAnnualSalary { get; set; }
        public decimal MaxAnnualSalary { get; set; }
        public double? ContactNumber { get; set; }
        public int NumberOfOpenings { get; set; }
        public string LocationOfJob { get; set; }
        public string Skills { get; set; }
        public DateTime? JobEndDate { get; set; }
        public DateTime? PostEndDate { get; set; }
        public string JobDescription { get; set; }
        public bool HSC { get; set; }
        public bool SSC { get; set; }
        public string Graduation { get; set; }
        public string PostGraduation { get; set; }
    }
    public class JobDetailsAddEditModel
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        [Display(Name = "First Name*")]
        [MaxLength(150)]
        public string FirstName { get; set; }
        [MaxLength(200)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Display(Name = "Personal Contact Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid contact number")]
        public double PersonalContactNumber { get; set; }
        [MaxLength(150)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Website*")]
        public string Website { get; set; }
        [MaxLength(150)]
        [Display(Name = "JobType")]
        public string JobType { get; set; }
        [Display(Name = "Job Start Date")]
        public DateTime JobStartDate { get; set; }
        [Required]
        [Display(Name = "Job Title*")]
        [MaxLength(200)]
        public string JobTitle { get; set; }
        [Display(Name = "Minimum Work Experience")]
        [RegularExpression(@"^(0|-?\d{0,2}(\.\d{0,2})?)$")]
        public decimal MinWorkExperience { get; set; }
        [Display(Name = "Maximum Work Experience")]
        [RegularExpression(@"^(0|-?\d{0,2}(\.\d{0,2})?)$")]
        public decimal MaxWorkExperience { get; set; }
        [Display(Name = "Minimum Annual Salary")]
        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$")]
        public decimal MinAnnualSalary { get; set; }
        [Display(Name = "Maximum Annual Salary")]
        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$")]
        public decimal MaxAnnualSalary { get; set; }
        [Display(Name = "Contact Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid contact number")]
        public double? ContactNumber { get; set; }
        [Display(Name = "Number Of Openings")]
        public int NumberOfOpenings { get; set; }
        [Display(Name = "Location Of Job")]
        [MaxLength(200)]
        public string LocationOfJob { get; set; }
        public string Skills { get; set; }
        [Display(Name = "Job End Date")]
        public DateTime JobEndDate { get; set; }
        [Display(Name = "Post End Date")]
        public DateTime PostEndDate { get; set; }
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }
        public bool HSC { get; set; }
        public bool SSC { get; set; }
        [MaxLength(200)]
        public string Graduation { get; set; }
        [Display(Name = "Post Graduation")]
        [MaxLength(200)]
        public string PostGraduation { get; set; }
    }
}
