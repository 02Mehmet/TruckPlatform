namespace Truck.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruckInspection_V3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trucks", "Week", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trucks", "Week");
        }
    }
}
