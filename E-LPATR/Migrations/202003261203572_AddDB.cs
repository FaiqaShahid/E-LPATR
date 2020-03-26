namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DelieveredRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Attachment = c.Binary(),
                        Description = c.String(),
                        Request_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.Request_Id)
                .Index(t => t.Request_Id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Cost = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        DeliveryTme = c.DateTime(nullable: false),
                        Payment_Id = c.Int(),
                        RequestStatus_Id = c.Int(),
                        Student_Id = c.Int(),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payments", t => t.Payment_Id)
                .ForeignKey("dbo.RequestStatus", t => t.RequestStatus_Id)
                .ForeignKey("dbo.Users", t => t.Student_Id)
                .ForeignKey("dbo.Users", t => t.Teacher_Id)
                .Index(t => t.Payment_Id)
                .Index(t => t.RequestStatus_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cost = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        PaidVia = c.String(),
                        PaymentStatus_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PaymentStatus", t => t.PaymentStatus_Id)
                .Index(t => t.PaymentStatus_Id);
            
            CreateTable(
                "dbo.PaymentStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Image = c.Binary(),
                        Password = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        JoinedOn = c.DateTime(nullable: false),
                        AccountStatus_Id = c.Int(),
                        Country_Id = c.Int(),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountStatus", t => t.AccountStatus_Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.AccountStatus_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Earnings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cost = c.String(),
                        EarningStatus_Id = c.Int(),
                        Request_Id = c.Int(),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EarningStatus", t => t.EarningStatus_Id)
                .ForeignKey("dbo.Requests", t => t.Request_Id)
                .ForeignKey("dbo.Users", t => t.Teacher_Id)
                .Index(t => t.EarningStatus_Id)
                .Index(t => t.Request_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.EarningStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Issue = c.String(),
                        Attachment = c.Binary(),
                        DateTime = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Attachment = c.Binary(),
                        DateTime = c.DateTime(nullable: false),
                        Student_Id = c.Int(),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Student_Id)
                .ForeignKey("dbo.Users", t => t.Teacher_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.PackagePlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CostPerHour = c.String(),
                        CostPerDay = c.String(),
                        CostPer3Days = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Image = c.Binary(),
                        Description = c.String(),
                        PackagePlan_Id = c.Int(),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PackagePlans", t => t.PackagePlan_Id)
                .ForeignKey("dbo.Users", t => t.Teacher_Id)
                .Index(t => t.PackagePlan_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.RequestMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Attachment = c.Binary(),
                        DateTime = c.DateTime(nullable: false),
                        Request_Id = c.Int(),
                        Student_Id = c.Int(),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.Request_Id)
                .ForeignKey("dbo.Users", t => t.Student_Id)
                .ForeignKey("dbo.Users", t => t.Teacher_Id)
                .Index(t => t.Request_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Request_Id = c.Int(),
                        Student_Id = c.Int(),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.Request_Id)
                .ForeignKey("dbo.Users", t => t.Student_Id)
                .ForeignKey("dbo.Users", t => t.Teacher_Id)
                .Index(t => t.Request_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.Binary(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Reviews", "Teacher_Id", "dbo.Users");
            DropForeignKey("dbo.Reviews", "Student_Id", "dbo.Users");
            DropForeignKey("dbo.Reviews", "Request_Id", "dbo.Requests");
            DropForeignKey("dbo.RequestMessages", "Teacher_Id", "dbo.Users");
            DropForeignKey("dbo.RequestMessages", "Student_Id", "dbo.Users");
            DropForeignKey("dbo.RequestMessages", "Request_Id", "dbo.Requests");
            DropForeignKey("dbo.Profiles", "Teacher_Id", "dbo.Users");
            DropForeignKey("dbo.Profiles", "PackagePlan_Id", "dbo.PackagePlans");
            DropForeignKey("dbo.Messages", "Teacher_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Student_Id", "dbo.Users");
            DropForeignKey("dbo.Issues", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Earnings", "Teacher_Id", "dbo.Users");
            DropForeignKey("dbo.Earnings", "Request_Id", "dbo.Requests");
            DropForeignKey("dbo.Earnings", "EarningStatus_Id", "dbo.EarningStatus");
            DropForeignKey("dbo.DelieveredRequests", "Request_Id", "dbo.Requests");
            DropForeignKey("dbo.Requests", "Teacher_Id", "dbo.Users");
            DropForeignKey("dbo.Requests", "Student_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Users", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Users", "AccountStatus_Id", "dbo.AccountStatus");
            DropForeignKey("dbo.Requests", "RequestStatus_Id", "dbo.RequestStatus");
            DropForeignKey("dbo.Requests", "Payment_Id", "dbo.Payments");
            DropForeignKey("dbo.Payments", "PaymentStatus_Id", "dbo.PaymentStatus");
            DropIndex("dbo.Subcategories", new[] { "Category_Id" });
            DropIndex("dbo.Reviews", new[] { "Teacher_Id" });
            DropIndex("dbo.Reviews", new[] { "Student_Id" });
            DropIndex("dbo.Reviews", new[] { "Request_Id" });
            DropIndex("dbo.RequestMessages", new[] { "Teacher_Id" });
            DropIndex("dbo.RequestMessages", new[] { "Student_Id" });
            DropIndex("dbo.RequestMessages", new[] { "Request_Id" });
            DropIndex("dbo.Profiles", new[] { "Teacher_Id" });
            DropIndex("dbo.Profiles", new[] { "PackagePlan_Id" });
            DropIndex("dbo.Messages", new[] { "Teacher_Id" });
            DropIndex("dbo.Messages", new[] { "Student_Id" });
            DropIndex("dbo.Issues", new[] { "User_Id" });
            DropIndex("dbo.Earnings", new[] { "Teacher_Id" });
            DropIndex("dbo.Earnings", new[] { "Request_Id" });
            DropIndex("dbo.Earnings", new[] { "EarningStatus_Id" });
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropIndex("dbo.Users", new[] { "Country_Id" });
            DropIndex("dbo.Users", new[] { "AccountStatus_Id" });
            DropIndex("dbo.Payments", new[] { "PaymentStatus_Id" });
            DropIndex("dbo.Requests", new[] { "Teacher_Id" });
            DropIndex("dbo.Requests", new[] { "Student_Id" });
            DropIndex("dbo.Requests", new[] { "RequestStatus_Id" });
            DropIndex("dbo.Requests", new[] { "Payment_Id" });
            DropIndex("dbo.DelieveredRequests", new[] { "Request_Id" });
            DropTable("dbo.Subcategories");
            DropTable("dbo.Skills");
            DropTable("dbo.Reviews");
            DropTable("dbo.RequestMessages");
            DropTable("dbo.Profiles");
            DropTable("dbo.PackagePlans");
            DropTable("dbo.Messages");
            DropTable("dbo.Issues");
            DropTable("dbo.EarningStatus");
            DropTable("dbo.Earnings");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.RequestStatus");
            DropTable("dbo.PaymentStatus");
            DropTable("dbo.Payments");
            DropTable("dbo.Requests");
            DropTable("dbo.DelieveredRequests");
            DropTable("dbo.Degrees");
            DropTable("dbo.Countries");
            DropTable("dbo.Categories");
            DropTable("dbo.AccountStatus");
        }
    }
}
