using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public enum vehicleenum { Truck, Bus, Car, Mc };

    public class Vehicle
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string RegNo { get; set; }

        [Required]
        public vehicleenum VehicleType { get; set; }

        [Required]
        [StringLength(20)]
        public string Brand { get; set; }

        [StringLength(10)]
        public string VehicleModel { get; set; }

        [Required]
        [StringLength(30)]
        public string Color { get; set; }

        [Required]
        [Range(1,10)]
        public int NoOfWheels { get; set; }

        public DateTime ParkTime { get; set; }

    }
}