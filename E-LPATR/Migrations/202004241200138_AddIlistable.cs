namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIlistable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Profiles", "Name", c => c.String());
            AddColumn("dbo.Profiles", "ProfileStatus_Id", c => c.Int());
            CreateIndex("dbo.Profiles", "ProfileStatus_Id");
            AddForeignKey("dbo.Profiles", "ProfileStatus_Id", "dbo.ProfileStatus", "Id");
            DropColumn("dbo.Profiles", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Title", c => c.String());
            DropForeignKey("dbo.Profiles", "ProfileStatus_Id", "dbo.ProfileStatus");
            DropIndex("dbo.Profiles", new[] { "ProfileStatus_Id" });
            DropColumn("dbo.Profiles", "ProfileStatus_Id");
            DropColumn("dbo.Profiles", "Name");
            DropTable("dbo.ProfileStatus");
        }
    }
}
