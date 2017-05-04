using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WYF.WebAPI.Data.Generators;
using WYF.WebAPI.Models.EntityModels.Common;
using WYF.WebAPI.Models.EntityModels.Job;

namespace WYF.WebAPI.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<WYF.WebAPI.Data.WyfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "WYF.WebAPI.Data.WyfDbContext";
            SetSqlGenerator("System.Data.SqlClient", new DefaultValueSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(WYF.WebAPI.Data.WyfDbContext context)
        {
            // Seed Roles
            SeedRoles(context);

            // Seed Cities
            SeedCities(context);

            // Seed Industries
            SeedIndustries(context);
        }


        private void SeedRoles(WyfDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var allRoles = new string[] { "User", "Admin", "Employer", "Employee" };
            foreach (var role in allRoles)
            {
                if (!roleManager.RoleExists(role))
                {
                    roleManager.Create(new IdentityRole(role));
                }
            }

            context.SaveChanges();
        }

        private void SeedCities(WyfDbContext context)
        {
            string[] citiesToSeed = new[]
            {
                "Blagoevgrad",
                "Burgas",
                "Dobrich",
                "Gabrovo",
                "Haskovo",
                "Kardzhali",
                "Kyustendil",
                "Lovech",
                "Montana",
                "Pazardzhik",
                "Pernik",
                "Pleven",
                "Plovdiv",
                "Razgrad",
                "Ruse",
                "Shumen",
                "Svishtov",
                "Silistra",
                "Sliven",
                "Smolyan",
                "Sofia",
                "Sofia Region",
                "Stara Zagora",
                "Targovishte",
                "Varna",
                "Veliko Tarnovo",
                "Vidin",
                "Vratsa",
                "Yambol",
                "Other Bulgarian",
                "Other Abroad"
            };

            foreach (var cityName in citiesToSeed)
            {
                context.Cities.AddOrUpdate(c => c.Name, new City() { Name = cityName });
                context.SaveChanges();
            }
        }

        private void SeedIndustries(WyfDbContext context)
        {
            string[] industries = new[]
            {
                "Accounting, Auditing",
                "Administrative And Support Services",
                "Advertising, Marketing, Pr",
                "Agriculture, Forestry And Fishing",
                "Architectural Services",
                "Arts, Entertainment",
                "Automobile Industry",
                "Banking, Finance, Investments",
                "Beauty Parlour",
                "Chemistry And Chemical Technologies",
                "Computer Hardware",
                "Computer Software",
                "Construction",
                "Consulting",
                "Courier Services",
                "Design, Computer Design, Creative",
                "Education, Training, Library",
                "Electronics, Electrotechnics",
                "Energetics, Electricity",
                "Engineering",
                "Food Industry",
                "Governmental, Municipal",
                "Healthcare, Medicine",
                "HR, Employment",
                "Insurance",
                "Internet, e-Commerce",
                "IT",
                "Legal, Law Enforcement",
                "Maintenance Support",
                "Management",
                "Manufacturing, Production",
                "Media",
                "Military",
                "Mining",
                "Non-Profit, Social Service",
                "Personal Care",
                "Pharmaceutical, Biotechnology",
                "Policy Making",
                "Real Estate",
                "Restaurant, Food Services",
                "Sales, Customer Support",
                "Security Services",
                "Social Activities",
                "Science",
                "Sports, Recreation, Rehabilitation",
                "Telecommunication",
                "Textile Industry",
                "Tourism, Hospitality",
                "Trade-Retail, Wholesale",
                "Translation Services",
                "Transportation, Logistics",
                "Other"
            };

            foreach (var industryName in industries)
            {
                context.Industries.AddOrUpdate(c => c.Name, new Industry() { Name = industryName });
                context.SaveChanges();
            }
        }
    }
}
