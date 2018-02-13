using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Garage2.Controllers;
using Garage2.DataAccessLayer;

namespace Garage2.Controllers
{
    public class HomeController : Controller
    {
        private GarageContext db = new GarageContext();

        public ActionResult Index()
        {
            // count no of vehicles in garage
            ViewBag.size = VehiclesController.garagesize;
            ViewBag.num = db.Vehicles.Count();

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