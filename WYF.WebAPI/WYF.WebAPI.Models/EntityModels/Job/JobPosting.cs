using System.Activities;
using System.Data;
using Ninject.Modules;
using WYF.WebAPI.Models.EntityModels.Profile;

namespace WYF.WebAPI.Models.EntityModels.Job
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums.Job;

    public class JobPosting
    {
        public JobPosting()
        {
            Languages = new HashSet<Languages>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index("IX_JobPosting_Title_Unique", IsUnique = true)]
        [MinLength(length: 6, ErrorMessage = "The allowed minimum length of the Title is 6 characters.")]
        public string Title { get; set; }

        [Required]
        [MinLength(length: 2, ErrorMessage = "The allowed minimum length of the Business Name is 2 characters.")]
        public string BusinessName { get; set; }
         
        public decimal Salary { get; set; }

        public int IndustryId { get; set; }

        [ForeignKey(name: "IndustryId")]
        public Industry Industry { get; set; }

        public WorkTime WorkTime { get; set; }

        [Required]
        [StringLength(maximumLength: 5)]
        public string Description { get; set; }

        public int PostingCreatorId;

        [ForeignKey(name: "PostingCreatorId")]
        public virtual Employer PostingCreator { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int LocationId { get; set; }

        [ForeignKey(name: "LocationId")]
        public Location Location { get; set; }

        public HierarchyLevel HierarchyLevel { get; set; }

        public bool IsDrivingLicenseRequired { get; set; }

        public IEnumerable<Languages> Languages { get; set; }

        public LanguageLevel LanguageLevel { get; set; }

        public Education Education { get; set; }
    }
}
