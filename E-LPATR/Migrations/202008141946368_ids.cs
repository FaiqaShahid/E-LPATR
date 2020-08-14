namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ids : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "Student_Id", "dbo.Users");
            DropForeignKey("dbo.Requests", "Teacher_Id", "dbo.Users");
            DropIndex("dbo.Requests", new[] { "Student_Id" });
            DropIndex("dbo.Requests", new[] { "Teacher_Id" });
            RenameColumn(table: "dbo.Requests", name: "Student_Id", newName: "StudentId");
            RenameColumn(table: "dbo.Requests", name: "Teacher_Id", newName: "TeacherId");
            AlterColumn("dbo.Requests", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Requests", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Requests", "StudentId");
            CreateIndex("dbo.Requests", "TeacherId");
            AddForeignKey("dbo.Requests", "StudentId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Requests", "TeacherId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "TeacherId", "dbo.Users");
            DropForeignKey("dbo.Requests", "StudentId", "dbo.Users");
            DropIndex("dbo.Requests", new[] { "TeacherId" });
            DropIndex("dbo.Requests", new[] { "StudentId" });
            AlterColumn("dbo.Requests", "TeacherId", c => c.Int());
            AlterColumn("dbo.Requests", "StudentId", c => c.Int());
            RenameColumn(table: "dbo.Requests", name: "TeacherId", newName: "Teacher_Id");
            RenameColumn(table: "dbo.Requests", name: "StudentId", newName: "Student_Id");
            CreateIndex("dbo.Requests", "Teacher_Id");
            CreateIndex("dbo.Requests", "Student_Id");
            AddForeignKey("dbo.Requests", "Teacher_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Requests", "Student_Id", "dbo.Users", "Id");
        }
    }
}
