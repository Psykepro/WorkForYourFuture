namespace WYF.WebAPI.Models.ViewModels.User
{
    public class UserInfoViewModel
    {
        public string Username { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }
}