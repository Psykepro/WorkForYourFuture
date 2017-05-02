using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WYF.WebAPI.Models.Utilities;

namespace WYF.WebAPI.Models.BindingModels.Job
{
    class AddJobPostingBindingModel
    {
        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [Display(Name = "Username")]
        [RegularExpression(pattern: RegexPatterns.USERNAME, ErrorMessage = ErrorMessages.MESSAGE_FOR_NOT_MATCHED_USERNAME)]
        public string Username { get; set; }

        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [Display(Name = "Email")]
        [RegularExpression(pattern: RegexPatterns.EMAIL, ErrorMessage = ErrorMessages.MESSAGE_FOR_NOT_MATCHED_EMAIL)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression(pattern: RegexPatterns.PASSWORD, ErrorMessage = ErrorMessages.MESSAGE_FOR_NOT_MATCHED_PASSWORD)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = ErrorMessages.MESSAGE_FOR_CONFIRM_PASSWORD)]
        public string ConfirmPassword { get; set; }
    }
}
