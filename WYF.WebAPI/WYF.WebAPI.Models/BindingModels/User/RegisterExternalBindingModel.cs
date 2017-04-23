using System.ComponentModel.DataAnnotations;

namespace WYF.WebAPI.Models.BindingModels.User
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}