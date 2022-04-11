using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Data.Entities
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }
        public virtual State State { get; set; }
        public string Name { get; set; }
    }
}
