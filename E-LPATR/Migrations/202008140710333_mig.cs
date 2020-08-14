namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requests", "Cost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Requests", "Cost", c => c.String());
        }
    }
}
