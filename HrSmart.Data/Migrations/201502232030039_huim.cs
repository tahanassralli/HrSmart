namespace HrSmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class huim : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RefferingEmployees", "TenantAdminId", "dbo.TenantAdmins");
            DropIndex("dbo.RefferingEmployees", new[] { "TenantAdminId" });
            DropColumn("dbo.RefferingEmployees", "TenantAdminId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RefferingEmployees", "TenantAdminId", c => c.Int(nullable: false));
            CreateIndex("dbo.RefferingEmployees", "TenantAdminId");
            AddForeignKey("dbo.RefferingEmployees", "TenantAdminId", "dbo.TenantAdmins", "TenantAdminID");
        }
    }
}
