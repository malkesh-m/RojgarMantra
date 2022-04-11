using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Data.Entities
{
    public class City 
    {
        [Key]
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
        public string Name { get; set; }

    }
}
