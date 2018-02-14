using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2.DataAccessLayer;
using Garage2.Models;

namespace Garage2.Controllers
{
    public class VehiclesController : Controller
    {
        
        private GarageContext db = new GarageContext();
        public const int pricePerTime = 100;
        public static int garagesize = 25;

        // count no of vehicles in garage
        public int CheckNoInGarage()
        {
            int c = db.Vehicles.GroupBy(v => v.ParkingSpace).Count();
            //return db.Vehicles.Count();
            return c;
        }

        // GET: Vehicles
        //public ActionResult Index()
        //{
        //    // count no of vehicles in garage
        //    ViewBag.size = garagesize;
        //    ViewBag.num = CheckNoInGarage();

        //    return View(db.Vehicles.ToList());
        //}

        public ActionResult Index(string sortOrder)
        {
            // count no of vehicles in garage
            ViewBag.size = garagesize;
            ViewBag.numSpace = CheckNoInGarage();
            ViewBag.numVehicle = db.Vehicles.Count();

            ViewBag.SpaceSortParm = String.IsNullOrEmpty(sortOrder) ? "space_desc" : "";
            ViewBag.RegNoSortParm = sortOrder == "RegNo" ? "regno_desc" : "RegNo";
            ViewBag.TypeSortParm = sortOrder == "Type" ? "type_desc" : "Type";
            ViewBag.BrandSortParm = sortOrder == "Brand" ? "brand_desc" : "Brand";
            ViewBag.ModelSortParm = sortOrder == "Model" ? "model_desc" : "Model";
            ViewBag.ColorSortParm = sortOrder == "Color" ? "color_desc" : "Color";
            ViewBag.ParkTimeSortParm = sortOrder == "ParkTime" ? "parktime_desc" : "ParkTime";
            var vehicles = db.Vehicles.Select(v => v);
            switch (sortOrder)
            {
                case "space_desc":
                    vehicles = vehicles.OrderByDescending(v => v.ParkingSpace);
                    break;
                case "RegNo":
                    vehicles = vehicles.OrderBy(v => v.RegNo);
                    break;
                case "regno_desc":
                    vehicles = vehicles.OrderByDescending(v => v.RegNo);
                    break;
                case "Type":
                    vehicles = vehicles.OrderBy(v => v.VehicleType);
                    break;
                case "type_desc":
                    vehicles = vehicles.OrderByDescending(v => v.VehicleType);
                    break;
                case "Brand":
                    vehicles = vehicles.OrderBy(v => v.Brand);
                    break;
                case "brand_desc":
                    vehicles = vehicles.OrderByDescending(v => v.Brand);
                    break;
                case "Model":
                    vehicles = vehicles.OrderBy(v => v.VehicleModel);
                    break;
                case "model_desc":
                    vehicles = vehicles.OrderByDescending(v => v.VehicleModel);
                    break;
                case "Color":
                    vehicles = vehicles.OrderBy(v => v.Color);
                    break;
                case "color_desc":
                    vehicles = vehicles.OrderByDescending(v => v.Color);
                    break;
                case "ParkTime":
                    vehicles = vehicles.OrderBy(v => v.ParkTime);
                    break;
                case "parktime_desc":
                    vehicles = vehicles.OrderByDescending(v => v.ParkTime);
                    break;
                default:
                    vehicles = vehicles.OrderBy(v => v.ParkingSpace);
                    break;
            }
            return View(vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            
            if(garagesize == CheckNoInGarage()) {
                return View("CreateFull");
            }
            else
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegNo,VehicleType,Brand,VehicleModel,Color,NoOfWheels,ParkTime")] Vehicle vehicle)
        {
            ViewBag.RegNoMessage = "";

            if (db.Vehicles.Where(v=>v.RegNo == vehicle.RegNo).Any())
            {
                ViewBag.RegNoMessage = "Registration No already exists in garage";
            }

            else if (ModelState.IsValid && CheckNoInGarage() < garagesize)
            {

                // Find first parking-space nuber that is not already used
                int pspace = 0;
                for (int i=1; i<=garagesize; i++)
                {
                    var spaceVehicles = db.Vehicles.Where(v => v.ParkingSpace == i);
                    var count = spaceVehicles.Count();
                    int vehiclesPerSpace = 1;
                    if (count > 0 && spaceVehicles.FirstOrDefault().VehicleType == vehicleenum.Mc && vehicle.VehicleType == vehicleenum.Mc)
                    {
                        vehiclesPerSpace = 3;
                    }

                    if (count < vehiclesPerSpace 
                        && (!BigVehicle(vehicle)
                        || !db.Vehicles.Where(v => v.ParkingSpace == i + 1).Any())
                        && (db.Vehicles.Where(v => v.ParkingSpace == i - 1).Any() ? !BigVehicle(db.Vehicles.Where(v => v.ParkingSpace == i - 1).FirstOrDefault()) : true))

                    {
                        pspace = i;
                        break;
                    }
                    else
                    {
                        pspace = 0;
                    }
                }

                vehicle.ParkTime = DateTime.Now;
                vehicle.ParkingSpace = pspace;
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            

            return View(vehicle);
        }

        public bool BigVehicle(Vehicle vehicle)
        {
            if (vehicle.VehicleType == vehicleenum.Bus || vehicle.VehicleType == vehicleenum.Truck)
            {
                return true;
            }
            return false;
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNo,VehicleType,Brand,VehicleModel,Color,NoOfWheels,ParkTime,ParkingSpace")] Vehicle vehicle)
        {
            ViewBag.RegNoMessage = "";

            if (db.Vehicles.Where(v => v.Id != vehicle.Id && v.RegNo == vehicle.RegNo).Any())
            {
                ViewBag.RegNoMessage = "Registration No already exists in garage";
            }

            else if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Checkout(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }



        public ActionResult Receipt(int? id)
        {
            var model =
            db.Vehicles.Where(v => v.Id == id)
            .Select(v => new Garage2.Models.ReceiptViewModel
            {
                Id = v.Id,
                RegNo = v.RegNo,
                ParkTime = v.ParkTime,
                CheckOutTime = DateTime.Now,
                ParkedHrs = 0,
                Price = 0
            }).SingleOrDefault();
            model.ParkedHrs = Convert.ToInt32(Math.Ceiling((model.CheckOutTime - model.ParkTime).TotalHours));
            model.Price = model.ParkedHrs * pricePerTime;
            return View(model);
        }

        // POST: Vehicles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult FindVehicle()
        {
            string s1 = "Volvo";
            int aa = 20;

            //var model = db.Employees.Where(i => i.Department == "Sport" && i.Salary == 10).ToList();
            //var model = db.Employees.Where(i => i.Department == s1 && i.Salary < aa).ToList();
            var model = db.Vehicles.Where(i => i.Brand == s1).OrderByDescending(i => i.RegNo).ToList();
            /*
                var model =
                   from p in db.Employees
                   where p.Department == s1 && p.Salary < aa
                   select p;
            */
            return View(model);
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search([Bind(Include = "Id,RegNo,VehicleType,Brand")] Vehicle v1)
        {
            string rn = v1.RegNo;     
            string brand = v1.Brand;   
            var model =
               from p in db.Vehicles
               where (p.RegNo == rn || p.Brand == brand)
               select p;
            return View("FindVehicle", model);    // Back to FindVehicle view !
        }

        public ActionResult Statistics()
        {
            int parkingTime = 0;
            foreach (var item in db.Vehicles)
            {
                parkingTime += ComputeParkingTime(item.ParkTime, DateTime.Now);
            }
            var model = new StatisticsViewModel
                {
                    NoOfTrucks = db.Vehicles.Where(h => h.VehicleType == vehicleenum.Truck).Count(),
                    NoOfBuses = db.Vehicles.Where(h => h.VehicleType == vehicleenum.Bus).Count(),
                    NoOfCars = db.Vehicles.Where(h => h.VehicleType == vehicleenum.Car).Count(),
                    NoOfMcs = db.Vehicles.Where(h => h.VehicleType == vehicleenum.Mc).Count(),
                    WheelsTotal = db.Vehicles.Select(g => g.NoOfWheels).Sum(),
                    CurrentParkingValue = parkingTime * pricePerTime
            };

            return View(model);
        }

        private int ComputeParkingTime(DateTime checkin, DateTime checkout)
        {
            return Convert.ToInt32(Math.Ceiling((checkout - checkin).TotalHours));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
