namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewModelsProfile1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Name", c => c.String());
            DropColumn("dbo.Profiles", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Title", c => c.String());
            DropColumn("dbo.Profiles", "Name");
        }
    }
}
