using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using WYF.WebAPI;
using WYF.WebAPI.Models.BindingModels.Job;
using WYF.WebAPI.Models.BindingModels.User;
using WYF.WebAPI.Models.EntityModels.Job;
using WYF.WebAPI.Models.EntityModels.User;
using WYF.WebAPI.Models.ViewModels.Job;

[assembly: OwinStartup(typeof(Startup))]

namespace WYF.WebAPI
{
    public partial class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        public static GoogleOAuth2AuthenticationOptions GoogleAuthOptions { get; private set; }
        public static FacebookAuthenticationOptions FacebookAuthOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            try
            {
                // Enable Cross Origin Resource Sharing
                app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
                ConfigureAutoMapper();
                ConfigureAuth(app);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        private void ConfigureAutoMapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RegisterEmployeeBindingModel, Employee>();
                cfg.CreateMap<RegisterEmployerBindingModel, Employer>();
                cfg.CreateMap<AddJobPostingBindingModel, JobPosting>();
                cfg.CreateMap<JobPosting, JobPostingViewModel>();
            });

        }
    }
}
