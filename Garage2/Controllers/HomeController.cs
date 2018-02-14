using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Garage2.DataAccessLayer;

namespace Garage2.Controllers
{
    public class HomeController : Controller
    {

        // Points to the same db, just a new context, so that it can be accessed from here.
        private GarageContext db = new GarageContext();

        public ActionResult Index()
        {
            int v1 = db.Vehicles.Count();
            int s1 = db.Vehicles.GroupBy(v => v.ParkingSpace).Count();
            ViewBag.numSpace = s1;
            ViewBag.numVehicle = v1;
            ViewBag.size = VehiclesController.garagesize;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}