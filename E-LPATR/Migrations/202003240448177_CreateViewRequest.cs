namespace E_LPATR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateViewRequest : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Requests", name: "PaymentId_Id", newName: "Payment_Id");
            RenameColumn(table: "dbo.Requests", name: "RequestStatusId_Id", newName: "RequestStatus_Id");
            RenameColumn(table: "dbo.Requests", name: "TeacherId_Id", newName: "Teacher_Id");
            RenameIndex(table: "dbo.Requests", name: "IX_PaymentId_Id", newName: "IX_Payment_Id");
            RenameIndex(table: "dbo.Requests", name: "IX_RequestStatusId_Id", newName: "IX_RequestStatus_Id");
            RenameIndex(table: "dbo.Requests", name: "IX_TeacherId_Id", newName: "IX_Teacher_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Requests", name: "IX_Teacher_Id", newName: "IX_TeacherId_Id");
            RenameIndex(table: "dbo.Requests", name: "IX_RequestStatus_Id", newName: "IX_RequestStatusId_Id");
            RenameIndex(table: "dbo.Requests", name: "IX_Payment_Id", newName: "IX_PaymentId_Id");
            RenameColumn(table: "dbo.Requests", name: "Teacher_Id", newName: "TeacherId_Id");
            RenameColumn(table: "dbo.Requests", name: "RequestStatus_Id", newName: "RequestStatusId_Id");
            RenameColumn(table: "dbo.Requests", name: "Payment_Id", newName: "PaymentId_Id");
        }
    }
}
