using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RojgarMantra.Core.Models;

namespace RojgarMantra.Data.Entities
{
    public class JobDetails
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        public double PersonalContactNumber { get; set; }
        [MaxLength(150)]
        public string CompanyName { get; set; }
        [Required]
        public string Website { get; set; }
        [MaxLength(150)]
        public string JobType { get; set; }
        public DateTime? JobStartDate { get; set; }
        [Required]
        [MaxLength(200)]
        public string JobTitle { get; set; }
        [RegularExpression(@"^(0|-?\d{0,2}(\.\d{0,2})?)$")]
        public decimal MinWorkExperience { get; set; }
        [RegularExpression(@"^(0|-?\d{0,2}(\.\d{0,2})?)$")]
        public decimal MaxWorkExperience { get; set; }
        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$")]
        public decimal MinAnnualSalary { get; set; }
        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$")]
        public decimal MaxAnnualSalary { get; set; }
        public double? ContactNumber { get; set; }
        public int NumberOfOpenings { get; set; }
        [MaxLength(200)]
        public string LocationOfJob { get; set; }
        public string Skills { get; set; }
        public DateTime? JobEndDate { get; set; }
        public DateTime? PostEndDate { get; set; }
        public string JobDescription { get; set; }
        public bool HSC { get; set; }
        public bool SSC { get; set; }

        public int DegreeId { get; set; }
        // [ForeignKey("DegreeId")]
        public virtual Degree Degree { get; set; }

        public int PostDegreeId { get; set; }
        // [ForeignKey("PostDegreeId")]
        public virtual Degree PostDegree { get; set; }
    }
}
