using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Data.Entities
{
    public class UserJobSeeker
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [MaxLength(200)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string MarriedStatus { get; set; }
        [Required]
        [MaxLength(50)]
        public string Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public bool PhysicallyChallenged { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        [Required]
        public double ContactNumber { get; set; }
        [Required]
        public double AlternateContactNumber { get; set; }
        [Required]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        [Required]
        public int StateId { get; set; }
        public virtual State State { get; set; }
        [Required]
        public int CityId { get; set; }
        public virtual City City { get; set; }
        [Required]
        [MaxLength(200)]
        public string PermanentLocation { get; set; }
        [Required]
        [MaxLength(200)]
        public string PrefferredLocation { get; set; }
        [Required]
        [MaxLength(200)]
        public string CurrentAddress { get; set; }
        [MaxLength(100)]
        public string CompanyName { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }
        [MaxLength(100)]
        public string TotalExperience { get; set; }
        [Required]
        [MaxLength(100)]
        public string Skills { get; set; }
        [MaxLength(100)]
        public string CurrentCTCLac { get; set; }
        [MaxLength(100)]
        public String CurrentCTCThousand { get; set; }
        [MaxLength(100)]
        public String ExpectedCurrentCTCThousand { get; set; }
        [MaxLength(100)]
        public string ExpectedCurrentCTCLac { get; set; }
        [MaxLength(100)]
        public string NegotiableExpectedCTC { get; set; }
        [MaxLength(100)]
        public string NoticePeriod { get; set; }
        public bool NegotiableNoticePeriod { get; set; }
        [MaxLength(100)]
        public string PrevCompanyName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime From { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime To { get; set; }
        public int Experience { get; set; }
        [Required]
        public int SSCMarks { get; set; }
        [Required]
        public string SSCCompletionYear { get; set; }
        [Required]
        public int HSCMarks { get; set; }
        [Required]
        public string HSCCompletionYear { get; set; }
        [Required]
        public int DegreeNameId { get; set; }
        public virtual Degree DegreeName { get; set; }
        [Required]
        public int PostDegreeNameId { get; set; }
        public virtual Degree PostDegreeName { get; set; }
        [Required]
        public int GraduationMarks { get; set; }
        [Required]
        public string GraduationCompletionYear { get; set; }
        [Required]
        [MaxLength(200)]
        public string GraduationCompletionInstituteUniversity { get; set; }

        [Required]
        public int PostGraduationMarks { get; set; }
        [Required]
        public string PostGraduationCompletionYear { get; set; }
        [Required]
        [MaxLength(200)]
        public string PostGraduationCompletionInstituteUniversity { get; set; }
        [MaxLength(100)]
        public string CourseName { get; set; }
        [MaxLength(100)]
        public string CourseCompletionDuration { get; set; }
        [MaxLength(100)]
        public String SelectLanguage { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Speak { get; set; }
        public string Resume { get; set; }
        // public string UserId { get; set; }
    }
}
