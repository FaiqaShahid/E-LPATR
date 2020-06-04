namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIlistable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProfileStatus", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProfileStatus", "Name", c => c.Int(nullable: false));
        }
    }
}
