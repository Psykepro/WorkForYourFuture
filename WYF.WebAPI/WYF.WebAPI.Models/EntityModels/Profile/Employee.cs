using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WYF.WebAPI.Models.EntityModels.Account;
using WYF.WebAPI.Models.EntityModels.Job;

namespace WYF.WebAPI.Models.EntityModels.Profile
{
    public class Employee : Person
    {
        public Employee()
        {
            this.JobCandidatures = new HashSet<JobApplication>();
        }

        [Required]
        [MinLength(length: 10, ErrorMessage = "The allowed minimum length of Experience is 10 characters.")]
        [MaxLength(length: 500, ErrorMessage = "The allowed maximum length of Experience is 500 characters.")]
        public string Experience { get; set; }

        public string MotivationalLetter { get; set; }

        public virtual IEnumerable<JobApplication> JobCandidatures { get; set; }

        [DataType("VARBINARY(MAX)")]
        public Byte[] Cv { get; set; }

        [Required]
        public bool IsLicensedDriver { get; set; }
    }
}
