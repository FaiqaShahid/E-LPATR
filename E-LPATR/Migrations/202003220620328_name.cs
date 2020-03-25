namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.Users", new[] { "Profile_Id" });
            RenameColumn(table: "dbo.Payments", name: "PaymentStatusId_Id", newName: "PaymentStatus_Id");
            RenameColumn(table: "dbo.Users", name: "CoutryId_Id", newName: "Country_Id");
            RenameColumn(table: "dbo.Users", name: "RoleId_Id", newName: "Role_Id");
            RenameColumn(table: "dbo.Users", name: "AccountStatusId_Id", newName: "AccountStatus_Id");
            RenameColumn(table: "dbo.Profiles", name: "PackagePlanId_Id", newName: "PackagePlan_Id");
            RenameColumn(table: "dbo.Requests", name: "StudentId_Id", newName: "Student_Id");
            RenameColumn(table: "dbo.DelieveredRequests", name: "RequestId_Id", newName: "Request_Id");
            RenameColumn(table: "dbo.Earnings", name: "EarningStatusId_Id", newName: "EarningStatus_Id");
            RenameColumn(table: "dbo.Earnings", name: "RequestId_Id", newName: "Request_Id");
            RenameColumn(table: "dbo.Earnings", name: "TeacherId_Id", newName: "Teacher_Id");
            RenameColumn(table: "dbo.Issues", name: "UserId_Id", newName: "User_Id");
            RenameColumn(table: "dbo.Messages", name: "StudentId_Id", newName: "Student_Id");
            RenameColumn(table: "dbo.Messages", name: "TeacherId_Id", newName: "Teacher_Id");
            RenameColumn(table: "dbo.RequestMessages", name: "RequestId_Id", newName: "Request_Id");
            RenameColumn(table: "dbo.RequestMessages", name: "StudentId_Id", newName: "Student_Id");
            RenameColumn(table: "dbo.RequestMessages", name: "TeacherId_Id", newName: "Teacher_Id");
            RenameColumn(table: "dbo.Reviews", name: "RequestId_Id", newName: "Request_Id");
            RenameColumn(table: "dbo.Reviews", name: "StudentId_Id", newName: "Student_Id");
            RenameColumn(table: "dbo.Reviews", name: "TeacherId_Id", newName: "Teacher_Id");
            RenameColumn(table: "dbo.Subcategories", name: "CategoryId_Id", newName: "Category_Id");
            RenameIndex(table: "dbo.DelieveredRequests", name: "IX_RequestId_Id", newName: "IX_Request_Id");
            RenameIndex(table: "dbo.Requests", name: "IX_StudentId_Id", newName: "IX_Student_Id");
            RenameIndex(table: "dbo.Payments", name: "IX_PaymentStatusId_Id", newName: "IX_PaymentStatus_Id");
            RenameIndex(table: "dbo.Users", name: "IX_CoutryId_Id", newName: "IX_Country_Id");
            RenameIndex(table: "dbo.Users", name: "IX_RoleId_Id", newName: "IX_Role_Id");
            RenameIndex(table: "dbo.Users", name: "IX_AccountStatusId_Id", newName: "IX_AccountStatus_Id");
            RenameIndex(table: "dbo.Earnings", name: "IX_EarningStatusId_Id", newName: "IX_EarningStatus_Id");
            RenameIndex(table: "dbo.Earnings", name: "IX_RequestId_Id", newName: "IX_Request_Id");
            RenameIndex(table: "dbo.Earnings", name: "IX_TeacherId_Id", newName: "IX_Teacher_Id");
            RenameIndex(table: "dbo.Issues", name: "IX_UserId_Id", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Messages", name: "IX_StudentId_Id", newName: "IX_Student_Id");
            RenameIndex(table: "dbo.Messages", name: "IX_TeacherId_Id", newName: "IX_Teacher_Id");
            RenameIndex(table: "dbo.Profiles", name: "IX_PackagePlanId_Id", newName: "IX_PackagePlan_Id");
            RenameIndex(table: "dbo.RequestMessages", name: "IX_RequestId_Id", newName: "IX_Request_Id");
            RenameIndex(table: "dbo.RequestMessages", name: "IX_StudentId_Id", newName: "IX_Student_Id");
            RenameIndex(table: "dbo.RequestMessages", name: "IX_TeacherId_Id", newName: "IX_Teacher_Id");
            RenameIndex(table: "dbo.Reviews", name: "IX_RequestId_Id", newName: "IX_Request_Id");
            RenameIndex(table: "dbo.Reviews", name: "IX_StudentId_Id", newName: "IX_Student_Id");
            RenameIndex(table: "dbo.Reviews", name: "IX_TeacherId_Id", newName: "IX_Teacher_Id");
            RenameIndex(table: "dbo.Subcategories", name: "IX_CategoryId_Id", newName: "IX_Category_Id");
            DropColumn("dbo.Users", "Profile_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Profile_Id", c => c.Int());
            RenameIndex(table: "dbo.Subcategories", name: "IX_Category_Id", newName: "IX_CategoryId_Id");
            RenameIndex(table: "dbo.Reviews", name: "IX_Teacher_Id", newName: "IX_TeacherId_Id");
            RenameIndex(table: "dbo.Reviews", name: "IX_Student_Id", newName: "IX_StudentId_Id");
            RenameIndex(table: "dbo.Reviews", name: "IX_Request_Id", newName: "IX_RequestId_Id");
            RenameIndex(table: "dbo.RequestMessages", name: "IX_Teacher_Id", newName: "IX_TeacherId_Id");
            RenameIndex(table: "dbo.RequestMessages", name: "IX_Student_Id", newName: "IX_StudentId_Id");
            RenameIndex(table: "dbo.RequestMessages", name: "IX_Request_Id", newName: "IX_RequestId_Id");
            RenameIndex(table: "dbo.Profiles", name: "IX_PackagePlan_Id", newName: "IX_PackagePlanId_Id");
            RenameIndex(table: "dbo.Messages", name: "IX_Teacher_Id", newName: "IX_TeacherId_Id");
            RenameIndex(table: "dbo.Messages", name: "IX_Student_Id", newName: "IX_StudentId_Id");
            RenameIndex(table: "dbo.Issues", name: "IX_User_Id", newName: "IX_UserId_Id");
            RenameIndex(table: "dbo.Earnings", name: "IX_Teacher_Id", newName: "IX_TeacherId_Id");
            RenameIndex(table: "dbo.Earnings", name: "IX_Request_Id", newName: "IX_RequestId_Id");
            RenameIndex(table: "dbo.Earnings", name: "IX_EarningStatus_Id", newName: "IX_EarningStatusId_Id");
            RenameIndex(table: "dbo.Users", name: "IX_AccountStatus_Id", newName: "IX_AccountStatusId_Id");
            RenameIndex(table: "dbo.Users", name: "IX_Role_Id", newName: "IX_RoleId_Id");
            RenameIndex(table: "dbo.Users", name: "IX_Country_Id", newName: "IX_CoutryId_Id");
            RenameIndex(table: "dbo.Payments", name: "IX_PaymentStatus_Id", newName: "IX_PaymentStatusId_Id");
            RenameIndex(table: "dbo.Requests", name: "IX_Student_Id", newName: "IX_StudentId_Id");
            RenameIndex(table: "dbo.DelieveredRequests", name: "IX_Request_Id", newName: "IX_RequestId_Id");
            RenameColumn(table: "dbo.Subcategories", name: "Category_Id", newName: "CategoryId_Id");
            RenameColumn(table: "dbo.Reviews", name: "Teacher_Id", newName: "TeacherId_Id");
            RenameColumn(table: "dbo.Reviews", name: "Student_Id", newName: "StudentId_Id");
            RenameColumn(table: "dbo.Reviews", name: "Request_Id", newName: "RequestId_Id");
            RenameColumn(table: "dbo.RequestMessages", name: "Teacher_Id", newName: "TeacherId_Id");
            RenameColumn(table: "dbo.RequestMessages", name: "Student_Id", newName: "StudentId_Id");
            RenameColumn(table: "dbo.RequestMessages", name: "Request_Id", newName: "RequestId_Id");
            RenameColumn(table: "dbo.Messages", name: "Teacher_Id", newName: "TeacherId_Id");
            RenameColumn(table: "dbo.Messages", name: "Student_Id", newName: "StudentId_Id");
            RenameColumn(table: "dbo.Issues", name: "User_Id", newName: "UserId_Id");
            RenameColumn(table: "dbo.Earnings", name: "Teacher_Id", newName: "TeacherId_Id");
            RenameColumn(table: "dbo.Earnings", name: "Request_Id", newName: "RequestId_Id");
            RenameColumn(table: "dbo.Earnings", name: "EarningStatus_Id", newName: "EarningStatusId_Id");
            RenameColumn(table: "dbo.DelieveredRequests", name: "Request_Id", newName: "RequestId_Id");
            RenameColumn(table: "dbo.Requests", name: "Student_Id", newName: "StudentId_Id");
            RenameColumn(table: "dbo.Profiles", name: "PackagePlan_Id", newName: "PackagePlanId_Id");
            RenameColumn(table: "dbo.Users", name: "AccountStatus_Id", newName: "AccountStatusId_Id");
            RenameColumn(table: "dbo.Users", name: "Role_Id", newName: "RoleId_Id");
            RenameColumn(table: "dbo.Users", name: "Country_Id", newName: "CoutryId_Id");
            RenameColumn(table: "dbo.Payments", name: "PaymentStatus_Id", newName: "PaymentStatusId_Id");
            CreateIndex("dbo.Users", "Profile_Id");
            AddForeignKey("dbo.Users", "Profile_Id", "dbo.Profiles", "Id");
        }
    }
}
