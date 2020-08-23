namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInReview : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "Student_Id", "dbo.Users");
            DropForeignKey("dbo.Reviews", "Teacher_Id", "dbo.Users");
            DropForeignKey("dbo.Reviews", "Request_Id", "dbo.Requests");
            DropIndex("dbo.Reviews", new[] { "Request_Id" });
            DropIndex("dbo.Reviews", new[] { "Student_Id" });
            DropIndex("dbo.Reviews", new[] { "Teacher_Id" });
            RenameColumn(table: "dbo.Reviews", name: "Request_Id", newName: "RequestId");
            AddColumn("dbo.Reviews", "Stars", c => c.Single(nullable: false));
            AlterColumn("dbo.Reviews", "RequestId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "RequestId");
            AddForeignKey("dbo.Reviews", "RequestId", "dbo.Requests", "Id", cascadeDelete: true);
            DropColumn("dbo.Reviews", "Student_Id");
            DropColumn("dbo.Reviews", "Teacher_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Teacher_Id", c => c.Int());
            AddColumn("dbo.Reviews", "Student_Id", c => c.Int());
            DropForeignKey("dbo.Reviews", "RequestId", "dbo.Requests");
            DropIndex("dbo.Reviews", new[] { "RequestId" });
            AlterColumn("dbo.Reviews", "RequestId", c => c.Int());
            DropColumn("dbo.Reviews", "Stars");
            RenameColumn(table: "dbo.Reviews", name: "RequestId", newName: "Request_Id");
            CreateIndex("dbo.Reviews", "Teacher_Id");
            CreateIndex("dbo.Reviews", "Student_Id");
            CreateIndex("dbo.Reviews", "Request_Id");
            AddForeignKey("dbo.Reviews", "Request_Id", "dbo.Requests", "Id");
            AddForeignKey("dbo.Reviews", "Teacher_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Reviews", "Student_Id", "dbo.Users", "Id");
        }
    }
}
