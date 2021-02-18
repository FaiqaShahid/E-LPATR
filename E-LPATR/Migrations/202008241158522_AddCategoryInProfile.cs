namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryInProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "CategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "CategoryId");
        }
    }
}
