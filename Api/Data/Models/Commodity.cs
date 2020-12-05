using System.Collections.Generic;

namespace NotatnikMechanika.Api.Data.Models
{
    public class Commodity : EntityBase
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public virtual ICollection<OrderToCommodity> OrderToCommodities { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
