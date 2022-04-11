using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Data.Entities
{
    public class UserEmployer
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [MaxLength(200)]
        public string ContactName { get; set; }
        [MaxLength(200)]
        public string CompanyName { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        public double ContactNumber { get; set; }
        public string CompanyLink { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
/*        public int RoleId { get; set; }
        public virtual Role Role { get; set; }*/
        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }
        public int WorkExperience { get; set; }
        public string CompanyLogo { get; set; }

    }

    public class CountryAdd
    {

        [Key]
        public int CountryID { get; set; }
        [Required]


        [Display(Name = "CountryName")]
        public string CountryName { get; set; }



    }
}
