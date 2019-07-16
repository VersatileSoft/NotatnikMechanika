using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Shared.Models.Car
{
    public class CarModel
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; } //Rejestracja 
        public string Engine { get; set; }
        public string Power { get; set; }
        public string Vin { get; set; }
        public int CustomerId { get; set; }
    }
}
