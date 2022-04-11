using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Core.Models
{
    public class SMTPDetailsListModel
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
    }
    public class SMTPDetailsAddEditModel
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        public string SenderName { get; set; }
        [EmailAddress(ErrorMessage ="Invalid email address")]
        public string SenderEmail { get; set; }
    }
}
