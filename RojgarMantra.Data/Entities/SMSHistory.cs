using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Data.Entities
{
    public class SMSHistory
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string MobileNo { get; set; }
        [MaxLength(200)]
        public string TypeOfSMS { get; set; }
        public DateTime DateTime { get; set; }
    }
}
