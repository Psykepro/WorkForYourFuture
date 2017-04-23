namespace WYF.WebAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Experience = c.String(nullable: false, maxLength: 500),
                        MotivationalLetter = c.String(),
                        Cv = c.Binary(),
                        IsLicensedDriver = c.Boolean(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 15),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessName = c.String(nullable: false, maxLength: 20),
                        BulstatIdNumber = c.String(nullable: false, maxLength: 15),
                        BusinessWebsiteUrl = c.String(),
                        PhoneNumber = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 15),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Industries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobApplicantId = c.Int(nullable: false),
                        JobPostingCreatorId = c.Int(nullable: false),
                        JobPostingId = c.Int(nullable: false),
                        DateOfApplication = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.JobApplicantId, cascadeDelete: true)
                .ForeignKey("dbo.JobPostings", t => t.JobPostingId, cascadeDelete: true)
                .ForeignKey("dbo.Employers", t => t.JobPostingCreatorId, cascadeDelete: true)
                .Index(t => t.JobApplicantId)
                .Index(t => t.JobPostingCreatorId)
                .Index(t => t.JobPostingId);
            
            CreateTable(
                "dbo.JobPostings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 20),
                        BusinessName = c.String(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IndustryId = c.Int(nullable: false),
                        WorkTime = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 5),
                        PostingCreatorId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        LocationId = c.Int(nullable: false),
                        HierarchyLevel = c.Int(nullable: false),
                        IsDrivingLicenseRequired = c.Boolean(nullable: false),
                        LanguageLevel = c.Int(nullable: false),
                        Education = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Industries", t => t.IndustryId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Employers", t => t.PostingCreatorId)
                .Index(t => t.Title, unique: true, name: "IX_JobPosting_Title_Unique")
                .Index(t => t.IndustryId)
                .Index(t => t.PostingCreatorId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.JobApplications", "JobPostingCreatorId", "dbo.Employers");
            DropForeignKey("dbo.JobApplications", "JobPostingId", "dbo.JobPostings");
            DropForeignKey("dbo.JobPostings", "PostingCreatorId", "dbo.Employers");
            DropForeignKey("dbo.JobPostings", "LocationId", "dbo.Cities");
            DropForeignKey("dbo.JobPostings", "IndustryId", "dbo.Industries");
            DropForeignKey("dbo.JobApplications", "JobApplicantId", "dbo.Employees");
            DropForeignKey("dbo.Employers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.JobPostings", new[] { "LocationId" });
            DropIndex("dbo.JobPostings", new[] { "PostingCreatorId" });
            DropIndex("dbo.JobPostings", new[] { "IndustryId" });
            DropIndex("dbo.JobPostings", "IX_JobPosting_Title_Unique");
            DropIndex("dbo.JobApplications", new[] { "JobPostingId" });
            DropIndex("dbo.JobApplications", new[] { "JobPostingCreatorId" });
            DropIndex("dbo.JobApplications", new[] { "JobApplicantId" });
            DropIndex("dbo.Employers", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.JobPostings");
            DropTable("dbo.JobApplications");
            DropTable("dbo.Industries");
            DropTable("dbo.Employers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Employees");
            DropTable("dbo.Cities");
        }
    }
}
