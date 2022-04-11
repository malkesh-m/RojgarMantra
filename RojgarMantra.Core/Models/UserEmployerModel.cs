using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RojgarMantra.Core.Models
{
    public class UserEmployerListModel
    {
        public int Id { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
        public string Password { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public double ContactNumber { get; set; }
        public string CompanyLink { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }
        public string Role { get; set; }
        public int WorkExperience { get; set; }
    }
    public class UserEmployerAddEditModel
    {
        public int Id { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        [Required]
        [Display(Name ="First Name*")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; }
        [Display(Name = "Contact Name")]
        [MaxLength(200)]
        public string ContactName { get; set; }
        [Required]
        [Display(Name = "Company Name*")]
        [MaxLength(200)]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Email*")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(200)]
        public string Email { get; set; }

        [Display(Name = "Contact Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid contact number")]
        public double? ContactNumber { get; set; }
        [Display(Name = "Company Website Link")]
        public string CompanyLink { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        public string Designation { get; set; }
        public int Role { get; set; }
        [Display(Name = "Work Experience")]
        public int WorkExperience { get; set; }
        [Display(Name = "Company Logo")]
        public HttpPostedFileBase CompanyLogo { get; set; }
    }
}
