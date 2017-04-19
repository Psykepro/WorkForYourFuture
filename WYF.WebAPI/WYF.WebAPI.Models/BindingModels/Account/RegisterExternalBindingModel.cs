using System.ComponentModel.DataAnnotations;

namespace WYF.WebAPI.Models.BindingModels.Account
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}