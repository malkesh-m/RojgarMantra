using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Core.Models
{
    public class SMSHistoryListModel
    {
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public string TypeOfSMS { get; set; }
        public DateTime DateTime { get; set; }
    }
    public class SMSHistoryAddEditModel
    {
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public string TypeOfSMS { get; set; }
        public DateTime DateTime { get; set; }
    }
}
