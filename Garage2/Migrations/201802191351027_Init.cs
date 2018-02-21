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
                        ParkingSpace = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "MemberId", "dbo.Members");
            DropIndex("dbo.Vehicles", new[] { "MemberId" });
            DropTable("dbo.Members");
            DropTable("dbo.Vehicles");
        }
    }
}
