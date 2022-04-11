using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Data.Entities
{
    public class PlacementDrive
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [MaxLength(150)]
        public string JobTitle { get; set; }
        [MaxLength(150)]
        public string CompanyName { get; set; }
        public int NumberOfVacancies { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        [RegularExpression(@"^(0|-?\d{0,6}(\.\d{0,2})?)$")]
        public decimal Package { get; set; }
        public int DegreeId { get; set; }
        public virtual Degree Degree { get; set; }
        public int SelectionProcessId { get; set; }
        public virtual SelectionProcess SelectionProcess { get; set; }
        [MaxLength(200)]
        public string PrimaryCoOrdinatorName { get; set; }
        public double CoOrdinatorNumber { get; set; }
        public double CoOrdinatorAlternateNumber { get; set; }
        [MaxLength(200)]
        public string Venue { get; set; }
        [MaxLength(200)]
        public string EligibleCoursesCertifications { get; set; }
        [MaxLength(200)]
        public string JobLocation { get; set; }
        [MaxLength(150)]
        public string Timings { get; set; }
    }
}
