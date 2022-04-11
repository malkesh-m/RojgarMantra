using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Data.Entities
{
    public class Supplier : BaseAuditClass
    {
        public Supplier()
        {
            Orders = new HashSet<Order>();
        }

        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
