namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequestStatusId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "RequestStatus_Id", "dbo.RequestStatus");
            DropIndex("dbo.Requests", new[] { "RequestStatus_Id" });
            RenameColumn(table: "dbo.Requests", name: "RequestStatus_Id", newName: "RequestStatusId");
            AlterColumn("dbo.Requests", "RequestStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Requests", "RequestStatusId");
            AddForeignKey("dbo.Requests", "RequestStatusId", "dbo.RequestStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "RequestStatusId", "dbo.RequestStatus");
            DropIndex("dbo.Requests", new[] { "RequestStatusId" });
            AlterColumn("dbo.Requests", "RequestStatusId", c => c.Int());
            RenameColumn(table: "dbo.Requests", name: "RequestStatusId", newName: "RequestStatus_Id");
            CreateIndex("dbo.Requests", "RequestStatus_Id");
            AddForeignKey("dbo.Requests", "RequestStatus_Id", "dbo.RequestStatus", "Id");
        }
    }
}
