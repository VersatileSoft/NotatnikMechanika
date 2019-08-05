using NotatnikMechanika.Shared.Models.Car;
using NotatnikMechanika.Shared.Models.Customer;
using System;

namespace NotatnikMechanika.Core.Models
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
