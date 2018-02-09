namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNo = c.String(nullable: false, maxLength: 10),
                        VehicleType = c.Int(nullable: false),
                        Brand = c.String(nullable: false, maxLength: 20),
                        VehicleModel = c.String(maxLength: 10),
                        Color = c.String(nullable: false, maxLength: 30),
                        NoOfWheels = c.Int(nullable: false),
                        ParkTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
        }
    }
}
