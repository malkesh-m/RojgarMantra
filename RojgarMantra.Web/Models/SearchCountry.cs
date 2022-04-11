using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RojgarMantra.Models
{
    public class SearchCountry
    {
        public string IndexNo { get; set; }
        public string CountryName { get; set; }

        public string Action { get; set; }
        public List<SearchCountry> usersinfo { get; set; }

    }
}