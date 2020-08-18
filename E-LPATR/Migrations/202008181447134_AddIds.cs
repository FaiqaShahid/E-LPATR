namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "PackagePlan_Id", "dbo.PackagePlans");
            DropForeignKey("dbo.Profiles", "ProfileStatus_Id", "dbo.ProfileStatus");
            DropForeignKey("dbo.Profiles", "Subcategory_Id", "dbo.Subcategories");
            DropForeignKey("dbo.Profiles", "Teacher_Id", "dbo.Users");
            DropIndex("dbo.Profiles", new[] { "PackagePlan_Id" });
            DropIndex("dbo.Profiles", new[] { "ProfileStatus_Id" });
            DropIndex("dbo.Profiles", new[] { "Subcategory_Id" });
            DropIndex("dbo.Profiles", new[] { "Teacher_Id" });
            RenameColumn(table: "dbo.Profiles", name: "PackagePlan_Id", newName: "PackagePlanId");
            RenameColumn(table: "dbo.Profiles", name: "ProfileStatus_Id", newName: "ProfileStatusId");
            RenameColumn(table: "dbo.Profiles", name: "Subcategory_Id", newName: "SubcategoryId");
            RenameColumn(table: "dbo.Profiles", name: "Teacher_Id", newName: "TeacherId");
            AlterColumn("dbo.Profiles", "PackagePlanId", c => c.Int(nullable: false));
            AlterColumn("dbo.Profiles", "ProfileStatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Profiles", "SubcategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Profiles", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Profiles", "TeacherId");
            CreateIndex("dbo.Profiles", "ProfileStatusId");
            CreateIndex("dbo.Profiles", "SubcategoryId");
            CreateIndex("dbo.Profiles", "PackagePlanId");
            AddForeignKey("dbo.Profiles", "PackagePlanId", "dbo.PackagePlans", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Profiles", "ProfileStatusId", "dbo.ProfileStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Profiles", "SubcategoryId", "dbo.Subcategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Profiles", "TeacherId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "TeacherId", "dbo.Users");
            DropForeignKey("dbo.Profiles", "SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.Profiles", "ProfileStatusId", "dbo.ProfileStatus");
            DropForeignKey("dbo.Profiles", "PackagePlanId", "dbo.PackagePlans");
            DropIndex("dbo.Profiles", new[] { "PackagePlanId" });
            DropIndex("dbo.Profiles", new[] { "SubcategoryId" });
            DropIndex("dbo.Profiles", new[] { "ProfileStatusId" });
            DropIndex("dbo.Profiles", new[] { "TeacherId" });
            AlterColumn("dbo.Profiles", "TeacherId", c => c.Int());
            AlterColumn("dbo.Profiles", "SubcategoryId", c => c.Int());
            AlterColumn("dbo.Profiles", "ProfileStatusId", c => c.Int());
            AlterColumn("dbo.Profiles", "PackagePlanId", c => c.Int());
            RenameColumn(table: "dbo.Profiles", name: "TeacherId", newName: "Teacher_Id");
            RenameColumn(table: "dbo.Profiles", name: "SubcategoryId", newName: "Subcategory_Id");
            RenameColumn(table: "dbo.Profiles", name: "ProfileStatusId", newName: "ProfileStatus_Id");
            RenameColumn(table: "dbo.Profiles", name: "PackagePlanId", newName: "PackagePlan_Id");
            CreateIndex("dbo.Profiles", "Teacher_Id");
            CreateIndex("dbo.Profiles", "Subcategory_Id");
            CreateIndex("dbo.Profiles", "ProfileStatus_Id");
            CreateIndex("dbo.Profiles", "PackagePlan_Id");
            AddForeignKey("dbo.Profiles", "Teacher_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Profiles", "Subcategory_Id", "dbo.Subcategories", "Id");
            AddForeignKey("dbo.Profiles", "ProfileStatus_Id", "dbo.ProfileStatus", "Id");
            AddForeignKey("dbo.Profiles", "PackagePlan_Id", "dbo.PackagePlans", "Id");
        }
    }
}
