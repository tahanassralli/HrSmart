namespace HrSmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hui : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Condidates",
                c => new
                    {
                        CondidateID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        ReferringEmplyeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CondidateID)
                .ForeignKey("dbo.RefferingEmployees", t => t.ReferringEmplyeeId)
                .Index(t => t.ReferringEmplyeeId);
            
            CreateTable(
                "dbo.Interviews",
                c => new
                    {
                        InterviewID = c.Int(nullable: false, identity: true),
                        Interviewdate = c.DateTime(nullable: false),
                        Level = c.Int(nullable: false),
                        CondidateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InterviewID)
                .ForeignKey("dbo.Condidates", t => t.CondidateId)
                .Index(t => t.CondidateId);
            
            CreateTable(
                "dbo.JobOffers",
                c => new
                    {
                        JobOfferID = c.Int(nullable: false, identity: true),
                        NameJobOffer = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        PointGet = c.Int(nullable: false),
                        RecuterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobOfferID)
                .ForeignKey("dbo.Recruters", t => t.RecuterID)
                .Index(t => t.RecuterID);
            
            CreateTable(
                "dbo.Recruters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        organisationName = c.String(nullable: false),
                        organisationAddress = c.String(),
                        organisationPhone = c.Int(nullable: false),
                        Role = c.String(),
                        TenantAdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TenantAdmins", t => t.TenantAdminId)
                .Index(t => t.TenantAdminId);
            
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        RewardID = c.Int(nullable: false, identity: true),
                        PointNumberReward = c.Int(nullable: false),
                        RecuterID = c.Int(nullable: false),
                        ReferringEmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RewardID)
                .ForeignKey("dbo.Recruters", t => t.RecuterID)
                .ForeignKey("dbo.RefferingEmployees", t => t.ReferringEmployeeID)
                .Index(t => t.RecuterID)
                .Index(t => t.ReferringEmployeeID);
            
            CreateTable(
                "dbo.RefferingEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        organisationName = c.String(nullable: false),
                        organisationAddress = c.String(),
                        organisationPhone = c.Int(nullable: false),
                        Role = c.String(),
                        TenantAdminId = c.Int(nullable: false),
                        RewardCredit = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TenantAdmins", t => t.TenantAdminId)
                .Index(t => t.TenantAdminId);
            
            CreateTable(
                "dbo.TenantAdmins",
                c => new
                    {
                        TenantAdminID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        organisationName = c.String(nullable: false),
                        organisationAddress = c.String(),
                        organisationPhone = c.Int(nullable: false),
                        UserInterfaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TenantAdminID)
                .ForeignKey("dbo.UserInterfaces", t => t.UserInterfaceId)
                .Index(t => t.UserInterfaceId);
            
            CreateTable(
                "dbo.UserInterfaces",
                c => new
                    {
                        UserInterfaceID = c.Int(nullable: false, identity: true),
                        Logo = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserInterfaceID);
            
            CreateTable(
                "dbo.JobOfferCondidates",
                c => new
                    {
                        JobOffer_JobOfferID = c.Int(nullable: false),
                        Condidate_CondidateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobOffer_JobOfferID, t.Condidate_CondidateID })
                .ForeignKey("dbo.JobOffers", t => t.JobOffer_JobOfferID, cascadeDelete: true)
                .ForeignKey("dbo.Condidates", t => t.Condidate_CondidateID, cascadeDelete: true)
                .Index(t => t.JobOffer_JobOfferID)
                .Index(t => t.Condidate_CondidateID);
            
            CreateTable(
                "dbo.RefferingEmployeeJobOffers",
                c => new
                    {
                        RefferingEmployee_Id = c.Int(nullable: false),
                        JobOffer_JobOfferID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RefferingEmployee_Id, t.JobOffer_JobOfferID })
                .ForeignKey("dbo.RefferingEmployees", t => t.RefferingEmployee_Id, cascadeDelete: true)
                .ForeignKey("dbo.JobOffers", t => t.JobOffer_JobOfferID, cascadeDelete: true)
                .Index(t => t.RefferingEmployee_Id)
                .Index(t => t.JobOffer_JobOfferID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recruters", "TenantAdminId", "dbo.TenantAdmins");
            DropForeignKey("dbo.RefferingEmployees", "TenantAdminId", "dbo.TenantAdmins");
            DropForeignKey("dbo.TenantAdmins", "UserInterfaceId", "dbo.UserInterfaces");
            DropForeignKey("dbo.Rewards", "ReferringEmployeeID", "dbo.RefferingEmployees");
            DropForeignKey("dbo.RefferingEmployeeJobOffers", "JobOffer_JobOfferID", "dbo.JobOffers");
            DropForeignKey("dbo.RefferingEmployeeJobOffers", "RefferingEmployee_Id", "dbo.RefferingEmployees");
            DropForeignKey("dbo.Condidates", "ReferringEmplyeeId", "dbo.RefferingEmployees");
            DropForeignKey("dbo.Rewards", "RecuterID", "dbo.Recruters");
            DropForeignKey("dbo.JobOffers", "RecuterID", "dbo.Recruters");
            DropForeignKey("dbo.JobOfferCondidates", "Condidate_CondidateID", "dbo.Condidates");
            DropForeignKey("dbo.JobOfferCondidates", "JobOffer_JobOfferID", "dbo.JobOffers");
            DropForeignKey("dbo.Interviews", "CondidateId", "dbo.Condidates");
            DropIndex("dbo.RefferingEmployeeJobOffers", new[] { "JobOffer_JobOfferID" });
            DropIndex("dbo.RefferingEmployeeJobOffers", new[] { "RefferingEmployee_Id" });
            DropIndex("dbo.JobOfferCondidates", new[] { "Condidate_CondidateID" });
            DropIndex("dbo.JobOfferCondidates", new[] { "JobOffer_JobOfferID" });
            DropIndex("dbo.TenantAdmins", new[] { "UserInterfaceId" });
            DropIndex("dbo.RefferingEmployees", new[] { "TenantAdminId" });
            DropIndex("dbo.Rewards", new[] { "ReferringEmployeeID" });
            DropIndex("dbo.Rewards", new[] { "RecuterID" });
            DropIndex("dbo.Recruters", new[] { "TenantAdminId" });
            DropIndex("dbo.JobOffers", new[] { "RecuterID" });
            DropIndex("dbo.Interviews", new[] { "CondidateId" });
            DropIndex("dbo.Condidates", new[] { "ReferringEmplyeeId" });
            DropTable("dbo.RefferingEmployeeJobOffers");
            DropTable("dbo.JobOfferCondidates");
            DropTable("dbo.UserInterfaces");
            DropTable("dbo.TenantAdmins");
            DropTable("dbo.RefferingEmployees");
            DropTable("dbo.Rewards");
            DropTable("dbo.Recruters");
            DropTable("dbo.JobOffers");
            DropTable("dbo.Interviews");
            DropTable("dbo.Condidates");
        }
    }
}
