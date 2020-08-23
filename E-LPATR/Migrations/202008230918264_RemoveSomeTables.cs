namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSomeTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DelieveredRequests", "Request_Id", "dbo.Requests");
            DropForeignKey("dbo.Earnings", "EarningStatus_Id", "dbo.EarningStatus");
            DropForeignKey("dbo.Messages", "Student_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Teacher_Id", "dbo.Users");
            DropForeignKey("dbo.Earnings", "Request_Id", "dbo.Requests");
            DropForeignKey("dbo.Earnings", "Teacher_Id", "dbo.Users");
            DropIndex("dbo.DelieveredRequests", new[] { "Request_Id" });
            DropIndex("dbo.Earnings", new[] { "EarningStatus_Id" });
            DropIndex("dbo.Earnings", new[] { "Request_Id" });
            DropIndex("dbo.Earnings", new[] { "Teacher_Id" });
            DropIndex("dbo.Messages", new[] { "Student_Id" });
            DropIndex("dbo.Messages", new[] { "Teacher_Id" });
            RenameColumn(table: "dbo.Earnings", name: "Request_Id", newName: "RequestId");
            RenameColumn(table: "dbo.Earnings", name: "Teacher_Id", newName: "TeacherId");
            AlterColumn("dbo.Earnings", "Cost", c => c.Int(nullable: false));
            AlterColumn("dbo.Earnings", "RequestId", c => c.Int(nullable: false));
            AlterColumn("dbo.Earnings", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Earnings", "TeacherId");
            CreateIndex("dbo.Earnings", "RequestId");
            AddForeignKey("dbo.Earnings", "RequestId", "dbo.Requests", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Earnings", "TeacherId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Earnings", "EarningStatus_Id");
            DropTable("dbo.DelieveredRequests");
            DropTable("dbo.EarningStatus");
            DropTable("dbo.Messages");
            DropTable("dbo.Skills");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Attachment = c.Binary(),
                        DateTime = c.DateTime(nullable: false),
                        Student_Id = c.Int(),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EarningStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DelieveredRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Attachment = c.Binary(),
                        Description = c.String(),
                        Request_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Earnings", "EarningStatus_Id", c => c.Int());
            DropForeignKey("dbo.Earnings", "TeacherId", "dbo.Users");
            DropForeignKey("dbo.Earnings", "RequestId", "dbo.Requests");
            DropIndex("dbo.Earnings", new[] { "RequestId" });
            DropIndex("dbo.Earnings", new[] { "TeacherId" });
            AlterColumn("dbo.Earnings", "TeacherId", c => c.Int());
            AlterColumn("dbo.Earnings", "RequestId", c => c.Int());
            AlterColumn("dbo.Earnings", "Cost", c => c.String());
            RenameColumn(table: "dbo.Earnings", name: "TeacherId", newName: "Teacher_Id");
            RenameColumn(table: "dbo.Earnings", name: "RequestId", newName: "Request_Id");
            CreateIndex("dbo.Messages", "Teacher_Id");
            CreateIndex("dbo.Messages", "Student_Id");
            CreateIndex("dbo.Earnings", "Teacher_Id");
            CreateIndex("dbo.Earnings", "Request_Id");
            CreateIndex("dbo.Earnings", "EarningStatus_Id");
            CreateIndex("dbo.DelieveredRequests", "Request_Id");
            AddForeignKey("dbo.Earnings", "Teacher_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Earnings", "Request_Id", "dbo.Requests", "Id");
            AddForeignKey("dbo.Messages", "Teacher_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Messages", "Student_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Earnings", "EarningStatus_Id", "dbo.EarningStatus", "Id");
            AddForeignKey("dbo.DelieveredRequests", "Request_Id", "dbo.Requests", "Id");
        }
    }
}
