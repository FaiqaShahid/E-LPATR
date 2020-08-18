namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestMessages", "Reciever_Id", c => c.Int());
            AddColumn("dbo.RequestMessages", "Sender_Id", c => c.Int());
            CreateIndex("dbo.RequestMessages", "Reciever_Id");
            CreateIndex("dbo.RequestMessages", "Sender_Id");
            AddForeignKey("dbo.RequestMessages", "Reciever_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.RequestMessages", "Sender_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestMessages", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.RequestMessages", "Reciever_Id", "dbo.Users");
            DropIndex("dbo.RequestMessages", new[] { "Sender_Id" });
            DropIndex("dbo.RequestMessages", new[] { "Reciever_Id" });
            DropColumn("dbo.RequestMessages", "Sender_Id");
            DropColumn("dbo.RequestMessages", "Reciever_Id");
        }
    }
}
