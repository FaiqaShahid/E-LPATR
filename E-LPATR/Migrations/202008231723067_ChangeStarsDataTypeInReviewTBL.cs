namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStarsDataTypeInReviewTBL : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "Stars", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "Stars", c => c.Single(nullable: false));
        }
    }
}
