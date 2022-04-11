using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Core.Models
{
    public class RazorpayDetailsListModel
    {
        public int Id { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }
        public string AccountNo { get; set; }
        public bool VisibleOnApp { get; set; }
    }
    public class RazorpayDetailsAddEditModel
    {
        public int Id { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }
        public string AccountNo { get; set; }
        public bool VisibleOnApp { get; set; }
    }
}
