using System;

namespace Garage2.Controllers
{
    internal class ReceiptViewModel
    {
        public int Id { get; set; }
        public string RegNo { get; set; }
        public DateTime ParkTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public int ParkedHrs { get; set; }
        public int Price { get; set; }
    }
}