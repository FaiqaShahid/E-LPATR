namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveProfileFromRequestTbl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.Requests", new[] { "Profile_Id" });
            DropColumn("dbo.Requests", "Profile_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "Profile_Id", c => c.Int());
            CreateIndex("dbo.Requests", "Profile_Id");
            AddForeignKey("dbo.Requests", "Profile_Id", "dbo.Profiles", "Id");
        }
    }
}
