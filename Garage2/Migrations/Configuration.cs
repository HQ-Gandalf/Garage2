namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Garage2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2.DataAccessLayer.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage2.DataAccessLayer.GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Vehicles.AddOrUpdate(
               p => p.RegNo,
                 new Models.Vehicle { RegNo = "ABC123", VehicleType = vehicleenum.Car, Brand = "Volvo", VehicleModel = "S40",
                     Color = "Black", NoOfWheels =4, ParkTime = DateTime.Now,
                     ParkingSpace = 5
                 },
                 new Models.Vehicle
                 {
                     RegNo = "XYZ987",
                     VehicleType = vehicleenum.Car,
                     Brand = "Volvo",
                     VehicleModel = "S40",
                     Color = "Black",
                     NoOfWheels = 4,
                     ParkTime = DateTime.Now,
                     ParkingSpace = 2
                 },
                 new Models.Vehicle
                 {
                     RegNo = "ZRT888",
                     VehicleType = vehicleenum.Car,
                     Brand = "Porche",
                     VehicleModel = "S40",
                     Color = "Black",
                     NoOfWheels = 4,
                     ParkTime = DateTime.Now,
                     ParkingSpace = 7
                 },
                 new Models.Vehicle
                 {
                     RegNo = "YTR654",
                     VehicleType = vehicleenum.Car,
                     Brand = "Volvo",
                     VehicleModel = "S90",
                     Color = "Red",
                     NoOfWheels = 4,
                     ParkTime = DateTime.Now,
                     ParkingSpace = 3
                 },
                 new Models.Vehicle
                 {
                     RegNo = "XQW777",
                     VehicleType = vehicleenum.Car,
                     Brand = "Fiat",
                     VehicleModel = "S40",
                     Color = "Black",
                     NoOfWheels = 4,
                     ParkTime = DateTime.Now,
                     ParkingSpace = 1 
                 }

               );

        }
    }
}
