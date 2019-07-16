using System;

namespace NotatnikMechanika.Shared.Models.Order
{
    public class OrderModel
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateTime AcceptDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
