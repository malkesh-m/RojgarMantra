using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Core.Models
{
    public class SMSDetailsListModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SenderName { get; set; }
        public string Url { get; set; }
        public string Credit { get; set; }

    }
    public class SMSDetailsAddEditModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SenderName { get; set; }
        public string Url { get; set; }
        public string Credit { get; set; }

    }
}
