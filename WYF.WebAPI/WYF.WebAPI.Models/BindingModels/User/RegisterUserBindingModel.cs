using System.ComponentModel.DataAnnotations;
using WYF.WebAPI.Models.Utilities;

namespace WYF.WebAPI.Models.BindingModels.User
{
    public class RegisterUserBindingModel
    {

        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [Display(Name = "Username")]
        [RegularExpression(pattern: Constants.USERNAME_REGEX_PATTERN, ErrorMessage = ErrorMessages.MESSAGE_FOR_NOT_MATCHED_USERNAME)]
        public string Username { get; set; }

        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [Display(Name = "Email")]
        [RegularExpression(pattern: Constants.EMAIL_REGEX_PATTERN, ErrorMessage = ErrorMessages.MESSAGE_FOR_NOT_MATCHED_EMAIL)]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [Display(Name = "Password")]
        [RegularExpression(pattern: Constants.PASSWORD_REGEX_PATTERN, ErrorMessage = ErrorMessages.MESSAGE_FOR_NOT_MATCHED_PASSWORD)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = ErrorMessages.MESSAGE_FOR_MISSING_REQUIRED_FIELD)]
        [Compare(otherProperty: "Password", ErrorMessage = ErrorMessages.MESSAGE_FOR_CONFIRM_PASSWORD)]
        public string ConfirmPassword { get; set; }
    }
}