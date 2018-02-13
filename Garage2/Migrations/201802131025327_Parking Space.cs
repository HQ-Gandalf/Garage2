namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParkingSpace : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "ParkingSpace", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "ParkingSpace");
        }
    }
}
