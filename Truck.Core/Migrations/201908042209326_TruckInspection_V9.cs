namespace Truck.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruckInspection_V9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inspections", "Week", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inspections", "Week");
        }
    }
}
