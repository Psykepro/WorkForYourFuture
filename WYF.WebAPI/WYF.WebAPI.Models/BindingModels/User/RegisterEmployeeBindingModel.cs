using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WYF.WebAPI.Models.Utilities;

namespace WYF.WebAPI.Models.BindingModels.User
{
    public class RegisterEmployeeBindingModel
    {
        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [Display(Name = "Username")]
        [RegularExpression(pattern: Constants.USERNAME_REGEX_PATTERN, ErrorMessage = ErrorMessages.MESSAGE_FOR_NOT_MATCHED_USERNAME)]
        public string Username { get; set; }

        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [Display(Name = "Email")]
        [RegularExpression(pattern: Constants.EMAIL_REGEX_PATTERN, ErrorMessage = ErrorMessages.MESSAGE_FOR_NOT_MATCHED_EMAIL)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression(pattern: Constants.PASSWORD_REGEX_PATTERN, ErrorMessage = ErrorMessages.MESSAGE_FOR_NOT_MATCHED_PASSWORD)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = ErrorMessages.MESSAGE_FOR_CONFIRM_PASSWORD)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [Display(Name = "First Name")]
        [RegularExpression(pattern: Constants.NAME_REGEX_PATTERN, ErrorMessage = ErrorMessages.MESSAGE_FOR_NOT_MATCHED_NAME)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [Display(Name = "Last Name")]
        [RegularExpression(pattern: Constants.NAME_REGEX_PATTERN, ErrorMessage = ErrorMessages.MESSAGE_FOR_NOT_MATCHED_NAME)]
        public string LastName { get; set; }

        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
