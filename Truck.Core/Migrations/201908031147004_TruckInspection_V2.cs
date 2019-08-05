namespace Truck.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruckInspection_V2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Inspections", name: "Student_TruckID", newName: "Truck_TruckID");
            RenameIndex(table: "dbo.Inspections", name: "IX_Student_TruckID", newName: "IX_Truck_TruckID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Inspections", name: "IX_Truck_TruckID", newName: "IX_Student_TruckID");
            RenameColumn(table: "dbo.Inspections", name: "Truck_TruckID", newName: "Student_TruckID");
        }
    }
}
