using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Data.Entities
{
    public class JobAlertDetails
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [MaxLength(100)]
        public string Designation { get; set; }
        [MaxLength(200)]
        public string Location { get; set; }
        public int YearOfExperience { get; set; }
        [MaxLength(150)]
        public string NameOfJobAlert { get; set; }
        [MaxLength(150)]
        public string JobCategory { get; set; }
        public int WorkExperience { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        [MaxLength(150)]
        public string Role { get; set; }
        public string Skills { get; set; }
        public string NoticePeriod { get; set; }
        [RegularExpression(@"^(0|-?\d{0,6}(\.\d{0,2})?)$")]
        public decimal ExpectedCTCLac { get; set; }
        public int ExpectedCTCThousand { get; set; }
        public int NegotiableExpectedCTC { get; set; }
    }
}
