namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "AccountStatus_Id", "dbo.AccountStatus");
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "AccountStatus_Id" });
            DropIndex("dbo.Users", new[] { "Role_Id" });
            RenameColumn(table: "dbo.Users", name: "AccountStatus_Id", newName: "AccountStatusID");
            RenameColumn(table: "dbo.Users", name: "Role_Id", newName: "RoleID");
            AlterColumn("dbo.Users", "AccountStatusID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "RoleID", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "RoleID");
            CreateIndex("dbo.Users", "AccountStatusID");
            AddForeignKey("dbo.Users", "AccountStatusID", "dbo.AccountStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "RoleID", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Users", "AccountStatusID", "dbo.AccountStatus");
            DropIndex("dbo.Users", new[] { "AccountStatusID" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            AlterColumn("dbo.Users", "RoleID", c => c.Int());
            AlterColumn("dbo.Users", "AccountStatusID", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "RoleID", newName: "Role_Id");
            RenameColumn(table: "dbo.Users", name: "AccountStatusID", newName: "AccountStatus_Id");
            CreateIndex("dbo.Users", "Role_Id");
            CreateIndex("dbo.Users", "AccountStatus_Id");
            AddForeignKey("dbo.Users", "Role_Id", "dbo.Roles", "Id");
            AddForeignKey("dbo.Users", "AccountStatus_Id", "dbo.AccountStatus", "Id");
        }
    }
}
