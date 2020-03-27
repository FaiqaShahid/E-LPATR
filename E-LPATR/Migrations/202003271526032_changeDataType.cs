namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PackagePlans", "CostPerHour", c => c.Int(nullable: false));
            AlterColumn("dbo.PackagePlans", "CostPerDay", c => c.Int(nullable: false));
            AlterColumn("dbo.PackagePlans", "CostPer3Days", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PackagePlans", "CostPer3Days", c => c.String());
            AlterColumn("dbo.PackagePlans", "CostPerDay", c => c.String());
            AlterColumn("dbo.PackagePlans", "CostPerHour", c => c.String());
        }
    }
}
