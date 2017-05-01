using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WYF.WebAPI.Models.EntityModels.Job;
using WYF.WebAPI.Models.Utilities;

namespace WYF.WebAPI.Models.EntityModels.User
{
    public class Employer : Person
    {
        public Employer()
        {
            this.JobApplicants = new HashSet<JobApplication>();
            this.JobPostings = new HashSet<JobPosting>();
        }

        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [RegularExpression(pattern: Constants.BUSINESS_NAME_REGEX_PATTERN, ErrorMessage = ErrorMessages.MESSAGE_FOR_NOT_MATCHED_BUSINESS_NAME)]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [RegularExpression(pattern: Constants.BULSTAT_ID_NUMBER_REGEX_PATTERN, ErrorMessage = ErrorMessages.MESSAGE_FOR_NOT_MATCHED_BULSTAT_ID_NUMBER)]
        public string BulstatIdNumber { get; set; }

        public string BusinessWebsiteUrl { get; set; }

        [RegularExpression(pattern: Constants.PHONE_REGEX_PATTERN, ErrorMessage = ErrorMessages.MESSAGE_FOR_NOT_MATCHED_PHONE)]
        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        public string PhoneNumber { get; set; }

        public virtual IEnumerable<JobApplication> JobApplicants { get; set; }

        public virtual IEnumerable<JobPosting> JobPostings { get; set; }
    }
}
