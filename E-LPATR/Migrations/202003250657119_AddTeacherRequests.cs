namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeacherRequests : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeachersRequests", "Teacher_Id", "dbo.Users");
            DropIndex("dbo.TeachersRequests", new[] { "Teacher_Id" });
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherRequests_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.TeacherRequests_Id)
                .Index(t => t.TeacherRequests_Id);
            
            DropTable("dbo.TeachersRequests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TeachersRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Teachers", "TeacherRequests_Id", "dbo.Users");
            DropIndex("dbo.Teachers", new[] { "TeacherRequests_Id" });
            DropTable("dbo.Teachers");
            CreateIndex("dbo.TeachersRequests", "Teacher_Id");
            AddForeignKey("dbo.TeachersRequests", "Teacher_Id", "dbo.Users", "Id");
        }
    }
}
