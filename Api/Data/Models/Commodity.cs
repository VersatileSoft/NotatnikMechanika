using System.Collections.Generic;

namespace NotatnikMechanika.Data.Models
{
    public class Commodity : EntityBase
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public virtual IEnumerable<OrderToCommodity> OrderToCommodities { get; set; }
    }
}
