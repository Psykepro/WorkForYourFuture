using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace WYF.WebAPI.Models.Utilities
{
    public static class IdentityUtils
    {
        public static IEnumerable<string> GetRolesFromIdentity(IPrincipal principal)
        {
            var roles = ((ClaimsIdentity)principal.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);

            return roles;
        }
    }
}
