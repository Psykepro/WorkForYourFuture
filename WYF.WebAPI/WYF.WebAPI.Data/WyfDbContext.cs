using Microsoft.AspNet.Identity.EntityFramework;
using WYF.WebAPI.Models.EntityModels.Account;

namespace WYF.WebAPI.Data
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class WyfDbContext : IdentityDbContext<User>
    {
        public WyfDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        

        public static WyfDbContext Create()
        {
            return new WyfDbContext();
        }
    }
}