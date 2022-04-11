using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Core.Models
{
    public class TemplateDetailsListModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
    }
    public class TemplateDetailsAddEditModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
    }
}
