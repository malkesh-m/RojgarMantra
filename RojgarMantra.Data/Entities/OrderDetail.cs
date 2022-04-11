using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Data.Entities
{
    public class OrderDetail
    {
        public OrderDetail()
        {
        }
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Qty { get; set; }
        public decimal SellPrice { get; set; }
        public decimal Total { get; set; }

        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}
