namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInIssuesTBL : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Issues", "User_Id", "dbo.Users");
            DropIndex("dbo.Issues", new[] { "User_Id" });
            AddColumn("dbo.Issues", "Name", c => c.String());
            AddColumn("dbo.Issues", "Email", c => c.String());
            AddColumn("dbo.Issues", "IssueMessage", c => c.String());
            DropColumn("dbo.Issues", "Issue");
            DropColumn("dbo.Issues", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Issues", "User_Id", c => c.Int());
            AddColumn("dbo.Issues", "Issue", c => c.String());
            DropColumn("dbo.Issues", "IssueMessage");
            DropColumn("dbo.Issues", "Email");
            DropColumn("dbo.Issues", "Name");
            CreateIndex("dbo.Issues", "User_Id");
            AddForeignKey("dbo.Issues", "User_Id", "dbo.Users", "Id");
        }
    }
}
