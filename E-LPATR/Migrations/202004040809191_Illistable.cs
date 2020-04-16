namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Illistable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Subcategory_Id", c => c.Int());
            CreateIndex("dbo.Profiles", "Subcategory_Id");
            AddForeignKey("dbo.Profiles", "Subcategory_Id", "dbo.Subcategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "Subcategory_Id", "dbo.Subcategories");
            DropIndex("dbo.Profiles", new[] { "Subcategory_Id" });
            DropColumn("dbo.Profiles", "Subcategory_Id");
        }
    }
}
