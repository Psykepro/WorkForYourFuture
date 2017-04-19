namespace WYF.WebAPI.Models.EntityModels.Job
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Profile;

    public class JobApplication
    {
        [Key]
        public int Id { get; set; }

        public Guid JobApplicantId { get; set; }

        [ForeignKey(name: "JobApplicantId")]
        public virtual Employee JobApplicant { get; set; }

        public Guid JobPostingCreatorId { get; set; }

        [ForeignKey(name: "JobPostingCreatorId")]
        public virtual Employer JobPostingCreator { get; set; }

        public int JobPostingId { get; set; }

        [ForeignKey(name: "JobPostingId")]
        public virtual JobPosting JobPosting { get; set; }

        public DateTime DateOfApplication { get; set; }
    }
}
