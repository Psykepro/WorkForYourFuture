using System.ComponentModel.DataAnnotations;
using WYF.WebAPI.Models.Utilities;

namespace WYF.WebAPI.Models.BindingModels.User
{
    public class RegisterUserBindingModel
    {

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [Display(Name = "Username")]
        [RegularExpression(pattern: RegexPatterns.USERNAME, ErrorMessage = ErrorMessages.NOT_MATCHED_USERNAME)]
        public string Username { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [Display(Name = "Email")]
        [RegularExpression(pattern: RegexPatterns.EMAIL, ErrorMessage = ErrorMessages.NOT_MATCHED_EMAIL)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [Display(Name = "Password")]
        [RegularExpression(pattern: RegexPatterns.PASSWORD, ErrorMessage = ErrorMessages.NOT_MATCHED_PASSWORD)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [Compare(otherProperty: "Password", ErrorMessage = ErrorMessages.CONFIRM_PASSWORD)]
        public string ConfirmPassword { get; set; }
    }
}