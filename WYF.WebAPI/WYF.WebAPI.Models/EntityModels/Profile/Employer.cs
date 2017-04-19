using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WYF.WebAPI.Models.EntityModels.Job;

namespace WYF.WebAPI.Models.EntityModels.Profile
{
    public class Employer : Person
    {
        public Employer()
        {
            this.JobApplicants = new HashSet<JobApplication>();
            this.JobPostings = new HashSet<JobPosting>();
        }

        [Required]
        [MinLength(length: 2, ErrorMessage = "The allowed minimum length of BusinessName is 2 characters.")]
        [MaxLength(length: 20, ErrorMessage = "The allowed maximum length of BusinessName is 20 characters.")]
        public string BusinessName { get; set; }

        [Required]
        [MinLength(length: 13, ErrorMessage = "The allowed minimum length of BulstatIdNumber is 13 characters.")]
        [MaxLength(length: 15, ErrorMessage = "The allowed maximum length of BulstatIdNumber is 15 characters.")]
        [RegularExpression(pattern: "^[0-9]+$", ErrorMessage = "The BulstatIdNumber can contains only digits.")]
        public string BulstatIdNumber { get; set; }

        public string BusinessWebsiteUrl { get; set; }

        [RegularExpression(pattern: "^[0-9]{9}$", ErrorMessage = "The phone number is invalid.")]
        public string PhoneNumber { get; set; }

        public virtual IEnumerable<JobApplication> JobApplicants { get; set; }

        public virtual IEnumerable<JobPosting> JobPostings { get; set; }
    }
}
