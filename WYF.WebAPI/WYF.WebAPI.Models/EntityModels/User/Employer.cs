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

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [RegularExpression(pattern: RegexPatterns.BUSINESS, ErrorMessage = ErrorMessages.NOT_MATCHED_BUSINESS_NAME)]
        [DataType("VARCHAR(30)")]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [RegularExpression(pattern: RegexPatterns.BULSTAT_ID_NUMBER, ErrorMessage = ErrorMessages.NOT_MATCHED_BULSTAT_ID_NUMBER)]
        [DataType("VARCHAR(15)")]
        public string BulstatIdNumber { get; set; }

        public string BusinessWebsiteUrl { get; set; }

        [RegularExpression(pattern: RegexPatterns.PHONE, ErrorMessage = ErrorMessages.NOT_MATCHED_PHONE)]
        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [DataType("VARCHAR(10)")]
        public string PhoneNumber { get; set; }

        public virtual IEnumerable<JobApplication> JobApplicants { get; set; }

        public virtual IEnumerable<JobPosting> JobPostings { get; set; }
    }
}
