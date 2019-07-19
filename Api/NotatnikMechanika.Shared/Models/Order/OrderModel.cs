﻿using System;
using System.Collections.Generic;

namespace NotatnikMechanika.Shared.Models.Order
{
    public class OrderModel
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public IEnumerable<int> ServicesIds { get; set; }
        public IEnumerable<int> CommoditiesIds { get; set; }
        public DateTime AcceptDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
