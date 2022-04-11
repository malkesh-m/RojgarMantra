using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Data.Entities
{
    public class SMTPDetails
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Host { get; set; }
        [MaxLength(150)]
        public string UserName { get; set; }
        [MaxLength(200)]
        public string Password { get; set; }
        [MaxLength(150)]
        public string Port { get; set; }
        [MaxLength(150)]
        public string SenderName { get; set; }
        [MaxLength(200)]
        public string SenderEmail { get; set; }
    }
}
