using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Core.Models
{
    public class ListInputModel
    {
        public string Echo { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public string Search { get; set; }
        public string SortColumn { get; set; }
        public string SortColumnDir { get; set; }
        //public int PageSize { get; set; }
        //public int Skip { get; set; }
    }

    public class ListOutputModel
    {
        public object Data { get; set; }
        public int RecordsTotal { get; set; }
    }
}
