namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "Describtion", c => c.String());
            AddColumn("dbo.Requests", "DeliveryTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Requests", "Profile_Id", c => c.Int());
            CreateIndex("dbo.Requests", "Profile_Id");
            AddForeignKey("dbo.Requests", "Profile_Id", "dbo.Profiles", "Id");
            DropColumn("dbo.Requests", "Description");
            DropColumn("dbo.Requests", "DeliveryTme");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "DeliveryTme", c => c.DateTime(nullable: false));
            AddColumn("dbo.Requests", "Description", c => c.String());
            DropForeignKey("dbo.Requests", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.Requests", new[] { "Profile_Id" });
            DropColumn("dbo.Requests", "Profile_Id");
            DropColumn("dbo.Requests", "DeliveryTime");
            DropColumn("dbo.Requests", "Describtion");
        }
    }
}
