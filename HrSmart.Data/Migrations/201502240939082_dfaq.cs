namespace HrSmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfaq : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Condidates", "ReferringEmplyeeId", "dbo.RefferingEmployees");
            DropForeignKey("dbo.JobOffers", "RecuterID", "dbo.Recruters");
            DropForeignKey("dbo.Rewards", "RecuterID", "dbo.Recruters");
            DropForeignKey("dbo.Recruters", "TenantAdminId", "dbo.TenantAdmins");
            DropForeignKey("dbo.Rewards", "ReferringEmployeeID", "dbo.RefferingEmployees");
            DropForeignKey("dbo.TenantAdmins", "UserInterfaceId", "dbo.UserInterfaces");
            DropIndex("dbo.Interviews", new[] { "CondidateId" });
            AlterColumn("dbo.Interviews", "CondidateId", c => c.Int());
            CreateIndex("dbo.Interviews", "CondidateId");
            AddForeignKey("dbo.Condidates", "ReferringEmplyeeId", "dbo.RefferingEmployees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobOffers", "RecuterID", "dbo.Recruters", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rewards", "RecuterID", "dbo.Recruters", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recruters", "TenantAdminId", "dbo.TenantAdmins", "TenantAdminID", cascadeDelete: true);
            AddForeignKey("dbo.Rewards", "ReferringEmployeeID", "dbo.RefferingEmployees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TenantAdmins", "UserInterfaceId", "dbo.UserInterfaces", "UserInterfaceID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TenantAdmins", "UserInterfaceId", "dbo.UserInterfaces");
            DropForeignKey("dbo.Rewards", "ReferringEmployeeID", "dbo.RefferingEmployees");
            DropForeignKey("dbo.Recruters", "TenantAdminId", "dbo.TenantAdmins");
            DropForeignKey("dbo.Rewards", "RecuterID", "dbo.Recruters");
            DropForeignKey("dbo.JobOffers", "RecuterID", "dbo.Recruters");
            DropForeignKey("dbo.Condidates", "ReferringEmplyeeId", "dbo.RefferingEmployees");
            DropIndex("dbo.Interviews", new[] { "CondidateId" });
            AlterColumn("dbo.Interviews", "CondidateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Interviews", "CondidateId");
            AddForeignKey("dbo.TenantAdmins", "UserInterfaceId", "dbo.UserInterfaces", "UserInterfaceID");
            AddForeignKey("dbo.Rewards", "ReferringEmployeeID", "dbo.RefferingEmployees", "Id");
            AddForeignKey("dbo.Recruters", "TenantAdminId", "dbo.TenantAdmins", "TenantAdminID");
            AddForeignKey("dbo.Rewards", "RecuterID", "dbo.Recruters", "Id");
            AddForeignKey("dbo.JobOffers", "RecuterID", "dbo.Recruters", "Id");
            AddForeignKey("dbo.Condidates", "ReferringEmplyeeId", "dbo.RefferingEmployees", "Id");
        }
    }
}
