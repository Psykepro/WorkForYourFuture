﻿using System.ComponentModel;
using WYF.WebAPI.Models.EntityModels.User;

namespace WYF.WebAPI.Models.EntityModels.Job
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class JobApplication
    {
        public JobApplication()
        {
            this.DateOfApplication = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public int JobApplicantId { get; set; }

        [ForeignKey(name: "JobApplicantId")]
        public virtual Employee JobApplicant { get; set; }

        public int JobPostingCreatorId { get; set; }

        [ForeignKey(name: "JobPostingCreatorId")]
        public virtual Employer JobPostingCreator { get; set; }

        public int JobPostingId { get; set; }

        [ForeignKey(name: "JobPostingId")]
        public virtual JobPosting JobPosting { get; set; }

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getutcdate()")]
        public DateTime DateOfApplication { get; set; }
    }
}
