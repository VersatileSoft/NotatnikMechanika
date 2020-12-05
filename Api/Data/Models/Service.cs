using System.Collections.Generic;

namespace NotatnikMechanika.Api.Data.Models
{
    public class Service : EntityBase
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public virtual ICollection<OrderToService> OrderToServices { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
