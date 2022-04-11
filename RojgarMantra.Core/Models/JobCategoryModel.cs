using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Core.Models
{
    public class JobCategoryListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOnText { get; set; }
        public string CreatedOnText { get; set; }
    }

    public class JobCategoryAddEditModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name="Name*")]
        public string Name { get; set; }
        [MaxLength(150)]
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        [MaxLength(150)]
        public string ModifiedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModifiedOn { get; set; }

        public string ModifiedOnText { get; set; }
        public string CreatedOnText { get; set; }
    }
}
