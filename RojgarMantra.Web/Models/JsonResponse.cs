using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RojgarMantra.Models
{
    public class JsonResponse
    {
        public string Status { get; set; }
        public object Date { get; set; }
        public string Message { get; set; }
    }
}