using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Registration No")]
        public string RegNo { get; set; }

        [Display(Name = "Park Time")]
        public DateTime ParkTime { get; set; }

        [Display(Name = "Check Out Time")]
        public DateTime CheckOutTime { get; set; }

        [Display(Name = "Parked Hours")]
        public int ParkedHrs { get; set; }

        [Display(Name = "To Pay")]
        public int Price { get; set; }
    }
}