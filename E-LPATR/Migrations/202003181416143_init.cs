namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                        Image = c.String(),
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
                "dbo.DelieveredRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Attachment = c.String(),
                        Description = c.String(),
                        RequestId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.RequestId_Id)
                .Index(t => t.RequestId_Id);
            
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
                        PaymentId_Id = c.Int(),
                        RequestStatusId_Id = c.Int(),
                        StudentId_Id = c.Int(),
                        TeacherId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payments", t => t.PaymentId_Id)
                .ForeignKey("dbo.RequestStatus", t => t.RequestStatusId_Id)
                .ForeignKey("dbo.Users", t => t.StudentId_Id)
                .ForeignKey("dbo.Users", t => t.TeacherId_Id)
                .Index(t => t.PaymentId_Id)
                .Index(t => t.RequestStatusId_Id)
                .Index(t => t.StudentId_Id)
                .Index(t => t.TeacherId_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cost = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        PaidVia = c.String(),
                        PaymentStatusId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PaymentStatus", t => t.PaymentStatusId_Id)
                .Index(t => t.PaymentStatusId_Id);
            
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
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Education = c.String(),
                        CV = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        JoinedOn = c.DateTime(nullable: false),
                        AccountStatusId_Id = c.Int(),
                        CoutryId_Id = c.Int(),
                        RoleId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountStatus", t => t.AccountStatusId_Id)
                .ForeignKey("dbo.Countries", t => t.CoutryId_Id)
                .ForeignKey("dbo.Roles", t => t.RoleId_Id)
                .Index(t => t.AccountStatusId_Id)
                .Index(t => t.CoutryId_Id)
                .Index(t => t.RoleId_Id);
            
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
                        EarningStatusId_Id = c.Int(),
                        RequestId_Id = c.Int(),
                        TeacherId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EarningStatus", t => t.EarningStatusId_Id)
                .ForeignKey("dbo.Requests", t => t.RequestId_Id)
                .ForeignKey("dbo.Users", t => t.TeacherId_Id)
                .Index(t => t.EarningStatusId_Id)
                .Index(t => t.RequestId_Id)
                .Index(t => t.TeacherId_Id);
            
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
                        Attachment = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        UserId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId_Id)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Attachment = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        StudentId_Id = c.Int(),
                        TeacherId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.StudentId_Id)
                .ForeignKey("dbo.Users", t => t.TeacherId_Id)
                .Index(t => t.StudentId_Id)
                .Index(t => t.TeacherId_Id);
            
            CreateTable(
                "dbo.PackagePlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Cost = c.String(),
                        Description = c.String(),
                        DeliveryTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Desciption = c.String(),
                        PackagePlanId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PackagePlans", t => t.PackagePlanId_Id)
                .Index(t => t.PackagePlanId_Id);
            
            CreateTable(
                "dbo.RequestMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Attachment = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        RequestId_Id = c.Int(),
                        StudentId_Id = c.Int(),
                        TeacherId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.RequestId_Id)
                .ForeignKey("dbo.Users", t => t.StudentId_Id)
                .ForeignKey("dbo.Users", t => t.TeacherId_Id)
                .Index(t => t.RequestId_Id)
                .Index(t => t.StudentId_Id)
                .Index(t => t.TeacherId_Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        RequestId_Id = c.Int(),
                        StudentId_Id = c.Int(),
                        TeacherId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.RequestId_Id)
                .ForeignKey("dbo.Users", t => t.StudentId_Id)
                .ForeignKey("dbo.Users", t => t.TeacherId_Id)
                .Index(t => t.RequestId_Id)
                .Index(t => t.StudentId_Id)
                .Index(t => t.TeacherId_Id);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        CategoryId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId_Id)
                .Index(t => t.CategoryId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategories", "CategoryId_Id", "dbo.Categories");
            DropForeignKey("dbo.Reviews", "TeacherId_Id", "dbo.Users");
            DropForeignKey("dbo.Reviews", "StudentId_Id", "dbo.Users");
            DropForeignKey("dbo.Reviews", "RequestId_Id", "dbo.Requests");
            DropForeignKey("dbo.RequestMessages", "TeacherId_Id", "dbo.Users");
            DropForeignKey("dbo.RequestMessages", "StudentId_Id", "dbo.Users");
            DropForeignKey("dbo.RequestMessages", "RequestId_Id", "dbo.Requests");
            DropForeignKey("dbo.Profiles", "PackagePlanId_Id", "dbo.PackagePlans");
            DropForeignKey("dbo.Messages", "TeacherId_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "StudentId_Id", "dbo.Users");
            DropForeignKey("dbo.Issues", "UserId_Id", "dbo.Users");
            DropForeignKey("dbo.Earnings", "TeacherId_Id", "dbo.Users");
            DropForeignKey("dbo.Earnings", "RequestId_Id", "dbo.Requests");
            DropForeignKey("dbo.Earnings", "EarningStatusId_Id", "dbo.EarningStatus");
            DropForeignKey("dbo.DelieveredRequests", "RequestId_Id", "dbo.Requests");
            DropForeignKey("dbo.Requests", "TeacherId_Id", "dbo.Users");
            DropForeignKey("dbo.Requests", "StudentId_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId_Id", "dbo.Roles");
            DropForeignKey("dbo.Users", "CoutryId_Id", "dbo.Countries");
            DropForeignKey("dbo.Users", "AccountStatusId_Id", "dbo.AccountStatus");
            DropForeignKey("dbo.Requests", "RequestStatusId_Id", "dbo.RequestStatus");
            DropForeignKey("dbo.Requests", "PaymentId_Id", "dbo.Payments");
            DropForeignKey("dbo.Payments", "PaymentStatusId_Id", "dbo.PaymentStatus");
            DropIndex("dbo.Subcategories", new[] { "CategoryId_Id" });
            DropIndex("dbo.Reviews", new[] { "TeacherId_Id" });
            DropIndex("dbo.Reviews", new[] { "StudentId_Id" });
            DropIndex("dbo.Reviews", new[] { "RequestId_Id" });
            DropIndex("dbo.RequestMessages", new[] { "TeacherId_Id" });
            DropIndex("dbo.RequestMessages", new[] { "StudentId_Id" });
            DropIndex("dbo.RequestMessages", new[] { "RequestId_Id" });
            DropIndex("dbo.Profiles", new[] { "PackagePlanId_Id" });
            DropIndex("dbo.Messages", new[] { "TeacherId_Id" });
            DropIndex("dbo.Messages", new[] { "StudentId_Id" });
            DropIndex("dbo.Issues", new[] { "UserId_Id" });
            DropIndex("dbo.Earnings", new[] { "TeacherId_Id" });
            DropIndex("dbo.Earnings", new[] { "RequestId_Id" });
            DropIndex("dbo.Earnings", new[] { "EarningStatusId_Id" });
            DropIndex("dbo.Users", new[] { "RoleId_Id" });
            DropIndex("dbo.Users", new[] { "CoutryId_Id" });
            DropIndex("dbo.Users", new[] { "AccountStatusId_Id" });
            DropIndex("dbo.Payments", new[] { "PaymentStatusId_Id" });
            DropIndex("dbo.Requests", new[] { "TeacherId_Id" });
            DropIndex("dbo.Requests", new[] { "StudentId_Id" });
            DropIndex("dbo.Requests", new[] { "RequestStatusId_Id" });
            DropIndex("dbo.Requests", new[] { "PaymentId_Id" });
            DropIndex("dbo.DelieveredRequests", new[] { "RequestId_Id" });
            DropTable("dbo.Subcategories");
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
            DropTable("dbo.Countries");
            DropTable("dbo.Categories");
            DropTable("dbo.AccountStatus");
        }
    }
}
