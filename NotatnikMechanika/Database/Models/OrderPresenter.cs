using System;

namespace NotatnikMechanika.Database.Models
{
    public class OrderPresenter
    {
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public string Details { get; set; }
        public DateTime StartOrderDate { get; set; }
        public DateTime FinishOrderDate { get; set; }
    }
}