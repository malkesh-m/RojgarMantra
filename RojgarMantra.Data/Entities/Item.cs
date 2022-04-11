using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace RojgarMantra.Data.Entities
{
    public class Item : BaseAuditClass
    {
        public Item()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [MaxLength(10)]
        public string ItemNo { get; set; }
        [MaxLength(100)]
        public string ItemDesc { get; set; }
        public decimal SellPrice { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
