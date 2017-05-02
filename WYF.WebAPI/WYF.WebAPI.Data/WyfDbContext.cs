using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using WYF.WebAPI.Data.Conventions;
using WYF.WebAPI.Models.EntityModels.Common;
using WYF.WebAPI.Models.EntityModels.User;

namespace WYF.WebAPI.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ////////////////////
            // EF Conventions //
            ////////////////////

            var attributeToColumnConvetion = new AttributeToColumnAnnotationConvention<DefaultValueAttribute, string>("SqlDefaultValue", (p, attributes) => attributes.SingleOrDefault().Value.ToString());
            modelBuilder.Conventions.Add(attributeToColumnConvetion);
            modelBuilder.Conventions.Add(new DataTypePropertyAttributeConvention());

            //////////////////////////////////
            // Concrete EntityModel Changes //
            //////////////////////////////////

            modelBuilder.Entity<JobPosting>()
                .HasRequired(p => p.PostingCreator)
                .WithMany()
                .WillCascadeOnDelete(false);
            
        }

        public static WyfDbContext Create()
        {
            return new WyfDbContext();
        }
    }
}