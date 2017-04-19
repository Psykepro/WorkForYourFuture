using WYF.WebAPI.Models.EntityModels.Profile;

namespace WYF.WebAPI.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels.Account;
    using Models.EntityModels.Job;
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class WyfDbContext : IdentityDbContext<User>
    {
        public WyfDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Employer> Employers { get; set; }

        public virtual DbSet<JobPosting> JobPostings { get; set; }

        public virtual DbSet<JobApplication> JobApplications { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Industry> Industries { get; set; }



        public static WyfDbContext Create()
        {
            return new WyfDbContext();
        }
    }
}