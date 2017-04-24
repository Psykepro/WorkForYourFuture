﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WYF.WebAPI.Models.EntityModels.Job;

namespace WYF.WebAPI.Models.EntityModels.User
{
    public class Employee : Person
    {
        public Employee()
        {
            this.JobCandidatures = new HashSet<JobApplication>();
        }

        public string Experience { get; set; }

        public string MotivationalLetter { get; set; }

        public virtual IEnumerable<JobApplication> JobCandidatures { get; set; }

        [DataType("VARBINARY(MAX)")]
        public byte[] Cv { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        /* Setting DefaultValue to 0 because the type of that property in the SQL is 'bit' */
        [DefaultValue(0)]
        [Column(name: "IsLicensedDriver")]
        public bool IsLicensedDriver { get; set; }
    }
}