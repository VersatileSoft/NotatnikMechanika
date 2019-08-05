using System;
using System.Collections.Generic;

namespace NotatnikMechanika.Shared.Models.Order
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Details { get; set; }
        public DateTime AcceptDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
