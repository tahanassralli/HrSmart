namespace HrSmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfaq2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recruters", "TenantAdminId", "dbo.TenantAdmins");
            DropForeignKey("dbo.TenantAdmins", "UserInterfaceId", "dbo.UserInterfaces");
            DropIndex("dbo.Recruters", new[] { "TenantAdminId" });
            DropIndex("dbo.TenantAdmins", new[] { "UserInterfaceId" });
            RenameColumn(table: "dbo.Recruters", name: "TenantAdminId", newName: "TenantAdmin_TenantAdminID");
            RenameColumn(table: "dbo.TenantAdmins", name: "UserInterfaceId", newName: "UserInterface_UserInterfaceID");
            AlterColumn("dbo.Recruters", "TenantAdmin_TenantAdminID", c => c.Int());
            AlterColumn("dbo.TenantAdmins", "UserInterface_UserInterfaceID", c => c.Int());
            CreateIndex("dbo.Recruters", "TenantAdmin_TenantAdminID");
            CreateIndex("dbo.TenantAdmins", "UserInterface_UserInterfaceID");
            AddForeignKey("dbo.Recruters", "TenantAdmin_TenantAdminID", "dbo.TenantAdmins", "TenantAdminID");
            AddForeignKey("dbo.TenantAdmins", "UserInterface_UserInterfaceID", "dbo.UserInterfaces", "UserInterfaceID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TenantAdmins", "UserInterface_UserInterfaceID", "dbo.UserInterfaces");
            DropForeignKey("dbo.Recruters", "TenantAdmin_TenantAdminID", "dbo.TenantAdmins");
            DropIndex("dbo.TenantAdmins", new[] { "UserInterface_UserInterfaceID" });
            DropIndex("dbo.Recruters", new[] { "TenantAdmin_TenantAdminID" });
            AlterColumn("dbo.TenantAdmins", "UserInterface_UserInterfaceID", c => c.Int(nullable: false));
            AlterColumn("dbo.Recruters", "TenantAdmin_TenantAdminID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.TenantAdmins", name: "UserInterface_UserInterfaceID", newName: "UserInterfaceId");
            RenameColumn(table: "dbo.Recruters", name: "TenantAdmin_TenantAdminID", newName: "TenantAdminId");
            CreateIndex("dbo.TenantAdmins", "UserInterfaceId");
            CreateIndex("dbo.Recruters", "TenantAdminId");
            AddForeignKey("dbo.TenantAdmins", "UserInterfaceId", "dbo.UserInterfaces", "UserInterfaceID", cascadeDelete: true);
            AddForeignKey("dbo.Recruters", "TenantAdminId", "dbo.TenantAdmins", "TenantAdminID", cascadeDelete: true);
        }
    }
}
