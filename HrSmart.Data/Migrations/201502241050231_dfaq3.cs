namespace HrSmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfaq3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recruters", "TenantAdmin_TenantAdminID", "dbo.TenantAdmins");
            DropIndex("dbo.Recruters", new[] { "TenantAdmin_TenantAdminID" });
            RenameColumn(table: "dbo.Recruters", name: "TenantAdmin_TenantAdminID", newName: "TenantAdminId");
            AlterColumn("dbo.Recruters", "TenantAdminId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recruters", "TenantAdminId");
            AddForeignKey("dbo.Recruters", "TenantAdminId", "dbo.TenantAdmins", "TenantAdminID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recruters", "TenantAdminId", "dbo.TenantAdmins");
            DropIndex("dbo.Recruters", new[] { "TenantAdminId" });
            AlterColumn("dbo.Recruters", "TenantAdminId", c => c.Int());
            RenameColumn(table: "dbo.Recruters", name: "TenantAdminId", newName: "TenantAdmin_TenantAdminID");
            CreateIndex("dbo.Recruters", "TenantAdmin_TenantAdminID");
            AddForeignKey("dbo.Recruters", "TenantAdmin_TenantAdminID", "dbo.TenantAdmins", "TenantAdminID");
        }
    }
}
