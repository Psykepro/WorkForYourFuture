namespace WYF.WebAPI.Models.ViewModels.User
{
    public class UserInfoViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }
}