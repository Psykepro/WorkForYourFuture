using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using WYF.WebAPI.Models.BindingModels.User;
using WYF.WebAPI.Models.EntityModels.User;
using WYF.WebAPI.Models.ViewModels.User;
using WYF.WebAPI.Providers;
using WYF.WebAPI.Results;
using System.Web.Http.Cors;
using WYF.WebAPI.Data;
using WYF.WebAPI.Models.Utilities;
using System.Web.Http.Results;

namespace WYF.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    [EnableCors("*", "*", "*")]
    public class UserController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;
        private WyfDbContext _context = WyfDbContext.Create();

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        // GET api/User/UserInfo
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("UserInfo")]
        public UserInfoViewModel GetUserInfo()
        {
            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            return new UserInfoViewModel
            {
                Username = User.Identity.GetUserName(),
                HasRegistered = externalLogin == null,
                LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
            };
        }

        // GET api/User/PersonInfo
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("PersonInfo")]
        public async Task<KeyValuePair<string, int>> GetPersonInfo()
        {
            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);
            WyfDbContext dbContext = new WyfDbContext();

            var roles = IdentityUtils.GetRolesFromIdentity(RequestContext.Principal.Identity);

            var identityUserId = RequestContext.Principal.Identity.GetUserId();
            KeyValuePair<string, int> pair = new KeyValuePair<string, int>();
            var employerRoleName = "Employer";
            var employeeRoleName = "Employee";

            if (roles.Contains(employerRoleName) && !roles.Contains(employeeRoleName))
            {
                Employer employer = await this._context.Employers.FirstOrDefaultAsync(e => e.UserId == identityUserId);
                pair = new KeyValuePair<string, int>(employerRoleName, employer.Id);
            }
            else if (roles.Contains(employeeRoleName) && !roles.Contains(employerRoleName))
            {
                try
                {
                    Employee employee =
                        await this._context.Employees.FirstOrDefaultAsync(e => e.UserId == identityUserId);
                    pair = new KeyValuePair<string, int>(employeeRoleName, employee.Id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("There are Person with the current user identity found in the database."),
                    ReasonPhrase = "Missing Resource Exception"
                });
            }

            return pair;
        }

        // POST api/User/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }



        // GET api/User/ManageInfo?returnUrl=%2F&generateState=true
        [Route("ManageInfo")]
        public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
        {
            IdentityUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user == null)
            {
                return null;
            }

            List<UserLoginInfoViewModel> logins = new List<UserLoginInfoViewModel>();

            foreach (IdentityUserLogin linkedAccount in user.Logins)
            {
                logins.Add(new UserLoginInfoViewModel
                {
                    LoginProvider = linkedAccount.LoginProvider,
                    ProviderKey = linkedAccount.ProviderKey
                });
            }

            if (user.PasswordHash != null)
            {
                logins.Add(new UserLoginInfoViewModel
                {
                    LoginProvider = LocalLoginProvider,
                    ProviderKey = user.UserName,
                });
            }

            return new ManageInfoViewModel
            {
                LocalLoginProvider = LocalLoginProvider,
                Email = user.Email,
                Logins = logins,
                ExternalLoginProviders = GetExternalLogins(returnUrl, generateState)
            };
        }

        // POST api/User/ChangePassword
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
                model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/User/SetPassword
        [Route("SetPassword")]
        public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/User/AddExternalLogin
        [Route("AddExternalLogin")]
        public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            AuthenticationTicket ticket = AccessTokenFormat.Unprotect(model.ExternalAccessToken);

            if (ticket == null || ticket.Identity == null || (ticket.Properties != null
                && ticket.Properties.ExpiresUtc.HasValue
                && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
            {
                return BadRequest("External login failure.");
            }

            ExternalLoginData externalData = ExternalLoginData.FromIdentity(ticket.Identity);

            if (externalData == null)
            {
                return BadRequest("The external login is already associated with an account.");
            }

            IdentityResult result = await UserManager.AddLoginAsync(User.Identity.GetUserId(),
                new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/User/RemoveLogin
        [Route("RemoveLogin")]
        public async Task<IHttpActionResult> RemoveLogin(RemoveLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result;

            if (model.LoginProvider == LocalLoginProvider)
            {
                result = await UserManager.RemovePasswordAsync(User.Identity.GetUserId());
            }
            else
            {
                result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(),
                    new UserLoginInfo(model.LoginProvider, model.ProviderKey));
            }

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            else
            {

            }

            return Ok();
        }

        // GET api/User/ExternalLogin
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [AllowAnonymous]
        [Route("ExternalLogin", Name = "ExternalLogin")]
        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        {
            if (error != null)
            {
                return Redirect(Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
            }

            if (!User.Identity.IsAuthenticated)
            {
                return new ChallengeResult(provider, this);
            }

            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return InternalServerError();
            }

            if (externalLogin.LoginProvider != provider)
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                return new ChallengeResult(provider, this);
            }

            User user = await UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider,
                externalLogin.ProviderKey));

            bool hasRegistered = user != null;

            if (hasRegistered)
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

                ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
                   OAuthDefaults.AuthenticationType);
                ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserManager,
                    CookieAuthenticationDefaults.AuthenticationType);

                AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
                Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
            }
            else
            {
                IEnumerable<Claim> claims = externalLogin.GetClaims();
                ClaimsIdentity identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
                Authentication.SignIn(identity);
            }

            return Ok();
        }

        // GET api/User/ExternalLogins?returnUrl=%2F&generateState=false
        [AllowAnonymous]
        [Route("ExternalLogins")]
        public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
        {
            IEnumerable<AuthenticationDescription> descriptions = Authentication.GetExternalAuthenticationTypes();
            List<ExternalLoginViewModel> logins = new List<ExternalLoginViewModel>();

            string state;

            if (generateState)
            {
                const int strengthInBits = 256;
                state = RandomOAuthStateGenerator.Generate(strengthInBits);
            }
            else
            {
                state = null;
            }

            foreach (AuthenticationDescription description in descriptions)
            {
                ExternalLoginViewModel login = new ExternalLoginViewModel
                {
                    Name = description.Caption,
                    Url = Url.Route("ExternalLogin", new
                    {
                        provider = description.AuthenticationType,
                        response_type = "token",
                        client_id = Startup.PublicClientId,
                        redirect_uri = new Uri(Request.RequestUri, returnUrl).AbsoluteUri,
                        state = state
                    }),
                    State = state
                };
                logins.Add(login);
            }

            return logins;
        }

        // POST api/User/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterUserBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User() { UserName = model.Username, Email = model.Email };

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            var rolesForUser = new[] { "User" };

            var resultOfAddingToRoles = await SafelyAddUserToRole(rolesForUser, user.Id);
            if (resultOfAddingToRoles == false)
            {
                return InternalServerError(new Exception("Adding user to role failed."));
            }

            return Ok(user.Id);
        }


        private async Task<bool> SafelyAddUserToRole(string[] rolesToAdd, string userId)
        {
            var roleStore = new RoleStore<IdentityRole>(this._context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            bool successOfAddingToRole = true;
            User user = _context.Users.Find(userId);

            foreach (var role in rolesToAdd)
            {
                bool isCurrentRoleExists = await roleManager.RoleExistsAsync(role);
                if (!isCurrentRoleExists)
                {
                    var resultNewRoleAdded = await roleManager.CreateAsync(new IdentityRole(role));
                    if (!resultNewRoleAdded.Succeeded)
                    {
                        successOfAddingToRole = false;
                    }
                }

                IdentityResult result = await UserManager.AddToRoleAsync(userId, role);

                if (!result.Succeeded)
                {
                    successOfAddingToRole = false;
                }
            }

            return successOfAddingToRole;
        }

        // POST api/User/RegisterEmployee
        [AllowAnonymous]
        [HttpPost]
        [Route("RegisterEmployee")]
        public async Task<IHttpActionResult> RegisterEmployee(RegisterEmployeeBindingModel model)
        {
            // Adding one day because of the bug with the Daylight Saving Time
            model.DateOfBirth = model.DateOfBirth.AddDays(1);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RegisterUserBindingModel employeeToUserBM = AutoMapper.Mapper.Map<RegisterUserBindingModel>(model);
            IHttpActionResult resultOfUserRegistering = await this.Register(employeeToUserBM);

            if(typeof(OkNegotiatedContentResult<string>) != resultOfUserRegistering.GetType())
            {
                return resultOfUserRegistering;
            }

            var userId = (resultOfUserRegistering as OkNegotiatedContentResult<string>).Content;
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var rolesForEmployee = new[] { "Employee" };
            var resultOfAddingToRoles = await SafelyAddUserToRole(rolesForEmployee, user.Id);

            if (resultOfAddingToRoles == false)
            {
                return InternalServerError(new Exception("Adding user to role failed."));
            }

            try
            {
                Employee newEmployee = AutoMapper.Mapper.Map<RegisterEmployeeBindingModel, Employee>(model);
                newEmployee.User = user;
                newEmployee.UserId = user.Id;

                _context.Employees.Add(newEmployee);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                InternalServerError(e);
                throw;
            }

            return Ok();
        }

        // POST api/User/RegisterEmployer
        [AllowAnonymous]
        [HttpPost]
        [Route("RegisterEmployer")]
        public async Task<IHttpActionResult> RegisterEmployer(RegisterEmployerBindingModel model)
        {
            // Adding one day because of the bug with the Daylight Saving Time
            model.DateOfBirth = model.DateOfBirth.AddDays(1);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RegisterUserBindingModel employerToUserBM = AutoMapper.Mapper.Map<RegisterUserBindingModel>(model);
            IHttpActionResult resultOfUserRegistering = await this.Register(employerToUserBM);

            if (typeof(OkNegotiatedContentResult<string>) != resultOfUserRegistering.GetType())
            {
                return resultOfUserRegistering;
            }

            var userId = (resultOfUserRegistering as OkNegotiatedContentResult<string>).Content;
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var rolesForEmployer = new[] { "Employer" };

            var resultOfAddingToRoles = await SafelyAddUserToRole(rolesForEmployer, user.Id);
            if (resultOfAddingToRoles == false)
            {
                return InternalServerError(new Exception("Adding user to role failed."));
            }

            try
            {

                Employer newEmployer = AutoMapper.Mapper.Map<RegisterEmployerBindingModel, Employer>(model);
                newEmployer.User = user;
                newEmployer.UserId = user.Id;

                _context.Employers.Add(newEmployer);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok();
        }

        // POST api/User/RegisterExternal
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("RegisterExternal")]
        public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var info = await Authentication.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return InternalServerError();
            }

            var user = new User() { UserName = model.Username, Email = model.Email };

            IdentityResult result = await UserManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            result = await UserManager.AddLoginAsync(user.Id, info.Login);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }


        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
            public string UserName { get; set; }

            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

                if (UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
                }

                return claims;
            }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || String.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                {
                    LoginProvider = providerKeyClaim.Issuer,
                    ProviderKey = providerKeyClaim.Value,
                    UserName = identity.FindFirstValue(ClaimTypes.Name)
                };
            }
        }

        private static class RandomOAuthStateGenerator
        {
            private static RandomNumberGenerator _random = new RNGCryptoServiceProvider();

            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
                }

                int strengthInBytes = strengthInBits / bitsPerByte;

                byte[] data = new byte[strengthInBytes];
                _random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }
        }

        #endregion
    }
}
