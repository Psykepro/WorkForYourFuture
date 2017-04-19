using System.ComponentModel.DataAnnotations;

namespace WYF.WebAPI.Models.BindingModels.Account
{
    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }
}