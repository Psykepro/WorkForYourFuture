using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WYF.WebAPI.Models.EntityModels.Common;
using WYF.WebAPI.Models.EntityModels.Job;
using WYF.WebAPI.Models.Utilities;

namespace WYF.WebAPI.Models.EntityModels.User
{
    public class Employee : Person
    {
        public Employee()
        {
            this.JobCandidatures = new HashSet<JobApplication>();
        }

        [StringLength(maximumLength: Constants.EMPLOYEE_EXPERIANCE_MAX_LENGTH, ErrorMessage = ErrorMessages.EMPLOYEE_EXPERIENCE)]
        [DataType("VARCHAR(500)")]
        public string Experience { get; set; }

        [StringLength(maximumLength: Constants.MOTIVATIONAL_LETTER_MAX_LENGTH, ErrorMessage = ErrorMessages.MOTIVATIONAL_LETTER)]
        [DataType("VARCHAR(500)")]
        public string MotivationalLetter { get; set; }

        public virtual ICollection<JobApplication> JobCandidatures { get; set; }

        [DataType("VARBINARY(MAX)")]
        public byte[] Cv { get; set; }

        /* Setting DefaultValue to 0 because the type of that property in the SQL is 'bit' */
        [DefaultValue(0)]
        [Column(name: "IsLicensedDriver")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        public bool IsLicensedDriver { get; set; }

        public City LivingLocation { get; set; }
    }
}
