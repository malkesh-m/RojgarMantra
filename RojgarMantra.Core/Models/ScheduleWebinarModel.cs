using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Core.Models
{
    public class ScheduleWebinarListModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public string PresenterName { get; set; }
        public string PresenterEmail { get; set; }
        public double? PresenterContactNumber { get; set; }
        public int WorkExperience { get; set; }
        public string Email { get; set; }
        public string PhysicalVirtual { get; set; }
        public string VirtualLink { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
    public class ScheduleWebinarAddEditModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(150)]
        public string PresenterName { get; set; }
        [MaxLength(200)]
        public string PresenterEmail { get; set; }
        public double? PresenterContactNumber { get; set; }
        public int WorkExperience { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        public string PhysicalVirtual { get; set; }
        public string VirtualLink { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
    }
}
