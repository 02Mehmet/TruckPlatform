namespace Truck.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruckInspection_V5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inspections", "InspectionDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inspections", "InspectionDate", c => c.DateTime(nullable: false));
        }
    }
}
