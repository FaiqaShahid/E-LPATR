namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDeliveryTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Requests", "DeliveryTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "DeliveryTime", c => c.DateTime(nullable: false));
        }
    }
}
