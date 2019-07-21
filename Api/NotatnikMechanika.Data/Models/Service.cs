using System.Collections.Generic;

namespace NotatnikMechanika.Data.Models
{
    public class Service : EntityBase
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public virtual IEnumerable<OrderToService> OrderToServices { get; set; }
    }
}
