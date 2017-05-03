using System;
using System.Collections.Generic;
using WYF.WebAPI.Models.EntityModels.User;
using WYF.WebAPI.Models.Enums.Common;
using WYF.WebAPI.Models.Enums.Job;

namespace WYF.WebAPI.Models.ViewModels.Job
{
    public class JobPostingViewModel
    {
        public JobPostingViewModel()
        {
            Languages = new HashSet<Language>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string BusinessName { get; set; }

        public decimal Salary { get; set; }

        public int IndustryId { get; set; }
        
        public WorkTime WorkTime { get; set; }

        public string Description { get; set; }

        public int PostingCreatorId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int LocationId { get; set; }

        public HierarchyLevel HierarchyLevel { get; set; }
        
        public bool IsDrivingLicenseRequired { get; set; }
        
        public ICollection<Language> Languages { get; set; }

        public LanguageLevel LanguageLevel { get; set; }

        public Education Education { get; set; }
    }
}
