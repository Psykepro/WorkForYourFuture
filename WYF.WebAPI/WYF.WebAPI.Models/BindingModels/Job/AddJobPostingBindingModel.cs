using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WYF.WebAPI.Models.EntityModels.Common;
using WYF.WebAPI.Models.EntityModels.Job;
using WYF.WebAPI.Models.EntityModels.User;
using WYF.WebAPI.Models.Enums.Common;
using WYF.WebAPI.Models.Enums.Job;
using WYF.WebAPI.Models.Utilities;

namespace WYF.WebAPI.Models.BindingModels.Job
{
    public class AddJobPostingBindingModel
    {
        public AddJobPostingBindingModel()
        {
            Languages = new HashSet<Language>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [Index("IX_JobPosting_Title_Unique", IsUnique = true)]
        [RegularExpression(pattern: RegexPatterns.JOB_TITLE, ErrorMessage = ErrorMessages.JOB_POSTING_TITLE)]
        [DataType("VARCHAR(35)")]
        public string Title { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [RegularExpression(pattern: RegexPatterns.BUSINESS_NAME, ErrorMessage = ErrorMessages.NOT_MATCHED_BUSINESS_NAME)]
        [DataType("VARCHAR(30)")]
        public string BusinessName { get; set; }

        public decimal Salary { get; set; }

        public int IndustryId { get; set; }

        [ForeignKey(name: "IndustryId")]
        public Industry Industry { get; set; }

        public WorkTime WorkTime { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [StringLength(maximumLength: Constants.JOB_DESCRIPTION_MAX_LENGTH, ErrorMessage = ErrorMessages.JOB_DESCRIPTION)]
        public string Description { get; set; }

        public int PostingCreatorId { get; set; }

        [ForeignKey(name: "PostingCreatorId")]
        public virtual Employer PostingCreator { get; set; }

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getutcdate()")]
        public DateTime CreationDate { get; set; }

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getutcdate()")]
        public DateTime? ExpirationDate { get; set; }

        public int LocationId { get; set; }

        [ForeignKey(name: "LocationId")]
        public City Location { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        public HierarchyLevel HierarchyLevel { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [DefaultValue(0)]
        public bool IsDrivingLicenseRequired { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        public IEnumerable<Language> Languages { get; set; }

        public LanguageLevel LanguageLevel { get; set; }

        public Education Education { get; set; }
    }
}
