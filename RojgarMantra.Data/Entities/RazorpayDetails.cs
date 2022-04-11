using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Data.Entities
{
    public class RazorpayDetails
    {
        [Key]
        public int Id { get; set; }
        public string ContactNo { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        [MaxLength(200)]
        public string Password { get; set; }
        [MaxLength(200)]
        public string AccountType { get; set; }
        [MaxLength(200)]
        public string AccountNo { get; set; }
        public bool VisibleOnApp { get; set; }
    }
}
