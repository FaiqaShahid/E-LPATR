namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActiveField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Active");
        }
    }
}
