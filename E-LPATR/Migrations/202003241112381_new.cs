namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeachersRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Teacher_Id)
                .Index(t => t.Teacher_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeachersRequests", "Teacher_Id", "dbo.Users");
            DropIndex("dbo.TeachersRequests", new[] { "Teacher_Id" });
            DropTable("dbo.TeachersRequests");
        }
    }
}
