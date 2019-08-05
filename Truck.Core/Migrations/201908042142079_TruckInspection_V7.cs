namespace Truck.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruckInspection_V7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inspections", "InspectionDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inspections", "InspectionDate", c => c.DateTime());
        }
    }
}
