using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Data.Entities
{
    public class SMSDetails
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string UserName { get; set; }
        [MaxLength(200)]
        public string Password { get; set; }
        [MaxLength(200)]
        public string SenderName { get; set; }
        [MaxLength(200)]
        public string Url { get; set; }
        [MaxLength(150)]
        public string Credit { get; set; }
    }
}
