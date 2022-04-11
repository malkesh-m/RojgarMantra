using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Data.Entities
{
    public class TemplateDetails
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string Subject { get; set; }
        [MaxLength(200)]
        public string Type { get; set; }
        public string Body { get; set; }
    }
}
