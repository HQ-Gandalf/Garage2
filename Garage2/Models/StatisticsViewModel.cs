using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class StatisticsViewModel
    {
        [Display(Name = "No of trucks")]
        public int NoOfTrucks { get; set; }

        [Display(Name = "No of buses")]
        public int NoOfBuses { get; set; }

        [Display(Name = "No of cars")]
        public int NoOfCars { get; set; }

        [Display(Name = "No of MCs")]
        public int NoOfMcs { get; set; }

        [Display(Name = "Total no of wheels")]
        public int WheelsTotal { get; set; }


        [Display(Name = "Total parking cost")]
        public int CurrentParkingValue { get; set; }
    }
}