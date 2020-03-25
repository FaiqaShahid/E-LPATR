namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class extends : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Users", "Profile_Id", c => c.Int());
            CreateIndex("dbo.Users", "Profile_Id");
            AddForeignKey("dbo.Users", "Profile_Id", "dbo.Profiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.Users", new[] { "Profile_Id" });
            DropColumn("dbo.Users", "Profile_Id");
            DropColumn("dbo.Users", "Discriminator");
        }
    }
}
