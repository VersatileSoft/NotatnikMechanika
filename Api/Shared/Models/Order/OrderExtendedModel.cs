﻿using NotatnikMechanika.Shared.Models.Car;
using NotatnikMechanika.Shared.Models.Customer;
using System;

namespace NotatnikMechanika.Shared.Models.Order
{
    public class OrderExtendedModel
    {
        public int Id { get; set; }
        public CustomerModel CustomerModel { get; set; }
        public CarModel CarModel { get; set; }
        public DateTime AcceptDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
