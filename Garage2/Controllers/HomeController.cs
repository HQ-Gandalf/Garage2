using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // count no of vehicles in garage
            ViewBag.size = VehiclesController.garagesize;
            ViewBag.num = VehiclesController.CheckNoInGarage();

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