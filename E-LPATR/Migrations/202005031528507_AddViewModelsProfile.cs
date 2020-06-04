namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewModelsProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Title", c => c.String());
            DropColumn("dbo.Profiles", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Name", c => c.String());
            DropColumn("dbo.Profiles", "Title");
        }
    }
}
