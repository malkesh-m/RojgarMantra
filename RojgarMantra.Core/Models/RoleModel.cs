using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RojgarMantra.Core.Models
{
    public class RoleListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CretedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class RoleAddEditModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name*")]
        public string Name { get; set; }
        public DateTime CretedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
