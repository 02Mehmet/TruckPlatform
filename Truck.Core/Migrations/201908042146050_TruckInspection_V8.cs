namespace Truck.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruckInspection_V8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inspections", "InspectionDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Trucks", "ProcessTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trucks", "ProcessTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Inspections", "InspectionDate", c => c.DateTime(nullable: false));
        }
    }
}
