using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Core.Models
{
    public class PlacementDriveListModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public int NumberOfVacancies { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal Package { get; set; }
        public string RequiredQualification { get; set; }
        public string SelectionProcess { get; set; }
        public string PrimaryCoOrdinatorName { get; set; }
        public double CoOrdinatorNumber { get; set; }
        public double CoOrdinatorAlternateNumber { get; set; }
        public string Venue { get; set; }
        public string EligibleCoursesCertifications { get; set; }
        public string JobLocation { get; set; }
        public string Timings { get; set; }
    }
    public class PlacementDriveAddEditModel
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Job Title*")]
        [MaxLength(150)]
        public string JobTitle { get; set; }
        [Required]
        [Display(Name = "Company Name*")]
        [MaxLength(150)]
        public string CompanyName { get; set; }
        [Display(Name = "Number Of Vacancies")]
        public int NumberOfVacancies { get; set; }
        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }
        [RegularExpression(@"^(0|-?\d{0,6}(\.\d{0,2})?)$")]
        public decimal Package { get; set; }
        [Display(Name = "Required Qualification")]
        [MaxLength(200)]
        public string RequiredQualification { get; set; }
        [Display(Name = "Selection Process")]
        [MaxLength(200)]
        public string SelectionProcess { get; set; }
        [Display(Name = "Primary Co-Ordinator Name")]
        [MaxLength(200)]
        public string PrimaryCoOrdinatorName { get; set; }
        [Display(Name = "Co-Ordinator Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid contact number")]
        public double? CoOrdinatorNumber { get; set; }
        [Display(Name = "Co-Ordinator Alternate Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid contact number")]
        public double? CoOrdinatorAlternateNumber { get; set; }
        [MaxLength(200)]
        public string Venue { get; set; }
        [Display(Name = "Eligible Courses Certifications")]
        [MaxLength(200)]
        public string EligibleCoursesCertifications { get; set; }
        [Display(Name = "Job Location")]
        [MaxLength(200)]
        public string JobLocation { get; set; }
        [MaxLength(150)]
        public string Timings { get; set; }
    }
}
