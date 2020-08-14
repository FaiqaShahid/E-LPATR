namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataTypeOfCost : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "Cost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "Cost", c => c.String());
        }
    }
}
