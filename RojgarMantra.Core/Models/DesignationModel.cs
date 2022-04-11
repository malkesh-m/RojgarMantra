using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Core.Models
{
    public class DesignationListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CretedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class DesignationAddEditModel
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
