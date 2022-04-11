using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RojgarMantra.Models
{
    public class CountryAdd
    {
       
        [Key]
        public int CountryID { get; set; }
        [Required]

     
        [Display(Name = "CountryName")]
        public string CountryName { get; set; }

        

    }


    public class statedetails
    {

        [Key]
        public int StateID { get; set; }
        [Required]


        //[Display(Name = "CountryName")]
        public string CountryName { get; set; }


        [Display(Name = "StateName")]
        public string StateName { get; set; }
    }


    
}