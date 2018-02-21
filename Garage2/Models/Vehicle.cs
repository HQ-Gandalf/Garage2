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
        [Display(Name = "Registration No")]
        public string RegNo { get; set; }

        [Required]
        [Display(Name = "Vehicle Type")]
        public vehicleenum VehicleType { get; set; }

        [Required]
        [StringLength(20)]
        public string Brand { get; set; }

        [StringLength(10)]
        [Display(Name = "Model")]
        public string VehicleModel { get; set; }

        [Required]
        [StringLength(30)]
        public string Color { get; set; }

        [Required]
        [Range(1,10)]
        [Display(Name = "No Of Wheels")]
        public int NoOfWheels { get; set; }

        [Display(Name = "Park Time")]
        public DateTime ParkTime { get; set; }

        [Display(Name = "Parking Space")]
        public int ParkingSpace { get; set; }

        // Added in Garage 2.5. Båda behövs. Sen Add-Migration, Update-Database, fixa till seed, update db igen.
        public int MemberId { get; set; }                 // foreign key prop som måste sättas av någon       
        public virtual Member Member { get; set; }        // navigational prop, set automatically, not in db..  
    }
}