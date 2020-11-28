using System.Collections.Generic;

namespace NotatnikMechanika.Data.Models
{
    public class Car : EntityBase
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; } //nr Rejestracyjny 
        public string Engine { get; set; }
        public string Power { get; set; }
        public string Vin { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
