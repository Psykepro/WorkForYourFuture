using System;
using System.Data.Entity.Migrations.Model;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WYF.WebAPI.Data.Generators;

namespace WYF.WebAPI.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<WYF.WebAPI.Data.WyfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WYF.WebAPI.Data.WyfDbContext";

            
            SetSqlGenerator("System.Data.SqlClient", new DefaultValueSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(WYF.WebAPI.Data.WyfDbContext context)
        {   // Seed Roles
            AddRoles(context);
            
        }


        private void AddRoles(WyfDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var allRoles = new string[] {"User", "Admin", "Employer", "Employee"};
            foreach (var role in allRoles)
            {
                roleManager.Create(new IdentityRole(role));
            }

            context.SaveChanges();
        }
    }
}
