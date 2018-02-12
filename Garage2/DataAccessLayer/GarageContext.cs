using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

// Persistent, ie database-file remains on disk between different
// runs of the application

namespace Garage2.DataAccessLayer
{
    public class GarageContext:DbContext
    {
        public GarageContext() : base("GarageFile")     
        {
        }

        public DbSet<Garage2.Models.Vehicle> Vehicles { get; set; }
    }
}