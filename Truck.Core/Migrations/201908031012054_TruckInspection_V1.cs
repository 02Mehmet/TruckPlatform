namespace Truck.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruckInspection_V1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inspections",
                c => new
                    {
                        InspectionID = c.Int(nullable: false, identity: true),
                        InspectionDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        Amount = c.Double(nullable: false),
                        Student_TruckID = c.Int(),
                    })
                .PrimaryKey(t => t.InspectionID)
                .ForeignKey("dbo.Trucks", t => t.Student_TruckID)
                .Index(t => t.Student_TruckID);
            
            CreateTable(
                "dbo.Trucks",
                c => new
                    {
                        TruckID = c.Int(nullable: false, identity: true),
                        PlateNumber = c.String(),
                        Status = c.Boolean(nullable: false),
                        ProcessTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TruckID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inspections", "Student_TruckID", "dbo.Trucks");
            DropIndex("dbo.Inspections", new[] { "Student_TruckID" });
            DropTable("dbo.Trucks");
            DropTable("dbo.Inspections");
        }
    }
}
