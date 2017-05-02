using System.ComponentModel.DataAnnotations;
using WYF.WebAPI.Models.Utilities;

namespace WYF.WebAPI.Models.BindingModels.User
{
    public class RegisterExternalBindingModel
    {
        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [Display(Name = "Username")]
        public string Username { get; set; }
    }
}