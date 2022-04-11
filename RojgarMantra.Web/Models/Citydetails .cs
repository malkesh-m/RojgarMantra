using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RojgarMantra.Models
{
    public class Citydetails
    {

        [Key]
        public int CityID { get; set; }
        [Required]


        [Display(Name = "CountryName")]
        public string CountryName { get; set; }


        [Display(Name = "StateName")]
        public string StateName { get; set; }


        [Display(Name = "DistrictName")]
        public string DistrictName { get; set; }

        [Display(Name = "CityName")]
        public string CityName { get; set; }
    }
}