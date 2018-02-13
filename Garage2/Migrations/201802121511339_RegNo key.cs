namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegNokey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Vehicles");
            AlterColumn("dbo.Vehicles", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Vehicles", "RegNo");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Vehicles");
            AlterColumn("dbo.Vehicles", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Vehicles", "Id");
        }
    }
}
