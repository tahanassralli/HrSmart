namespace HrSmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfaq4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recruters", "TenantAdminId", "dbo.TenantAdmins");
            DropIndex("dbo.Recruters", new[] { "TenantAdminId" });
            RenameColumn(table: "dbo.Recruters", name: "TenantAdminId", newName: "TenantAdmin_TenantAdminID");
            AlterColumn("dbo.Recruters", "TenantAdmin_TenantAdminID", c => c.Int());
            CreateIndex("dbo.Recruters", "TenantAdmin_TenantAdminID");
            AddForeignKey("dbo.Recruters", "TenantAdmin_TenantAdminID", "dbo.TenantAdmins", "TenantAdminID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recruters", "TenantAdmin_TenantAdminID", "dbo.TenantAdmins");
            DropIndex("dbo.Recruters", new[] { "TenantAdmin_TenantAdminID" });
            AlterColumn("dbo.Recruters", "TenantAdmin_TenantAdminID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Recruters", name: "TenantAdmin_TenantAdminID", newName: "TenantAdminId");
            CreateIndex("dbo.Recruters", "TenantAdminId");
            AddForeignKey("dbo.Recruters", "TenantAdminId", "dbo.TenantAdmins", "TenantAdminID", cascadeDelete: true);
        }
    }
}
