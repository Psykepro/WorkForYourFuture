using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [RegularExpression(pattern: RegexPatterns.JOB_TITLE, ErrorMessage = ErrorMessages.JOB_POSTING_TITLE)]
        public string Title { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [RegularExpression(pattern: RegexPatterns.BUSINESS_NAME, ErrorMessage = ErrorMessages.NOT_MATCHED_BUSINESS_NAME)]
        public string BusinessName { get; set; }
        
        public decimal Salary { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        public int IndustryId { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        public WorkTime WorkTime { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [StringLength(maximumLength: Constants.JOB_DESCRIPTION_MAX_LENGTH, ErrorMessage = ErrorMessages.JOB_DESCRIPTION)]
        public string Description { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        public int PostingCreatorId { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int LocationId { get; set; }

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
