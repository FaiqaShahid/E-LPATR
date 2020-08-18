namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInRequestMessage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RequestMessages", "Student_Id", "dbo.Users");
            DropForeignKey("dbo.RequestMessages", "Teacher_Id", "dbo.Users");
            DropIndex("dbo.RequestMessages", new[] { "Student_Id" });
            DropIndex("dbo.RequestMessages", new[] { "Teacher_Id" });
            DropColumn("dbo.RequestMessages", "Student_Id");
            DropColumn("dbo.RequestMessages", "Teacher_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequestMessages", "Teacher_Id", c => c.Int());
            AddColumn("dbo.RequestMessages", "Student_Id", c => c.Int());
            CreateIndex("dbo.RequestMessages", "Teacher_Id");
            CreateIndex("dbo.RequestMessages", "Student_Id");
            AddForeignKey("dbo.RequestMessages", "Teacher_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.RequestMessages", "Student_Id", "dbo.Users", "Id");
        }
    }
}
