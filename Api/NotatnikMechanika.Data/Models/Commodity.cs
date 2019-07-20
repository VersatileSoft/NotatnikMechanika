using System.Collections.Generic;

namespace NotatnikMechanika.Data.Models
{
    public class Commodity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual IEnumerable<OrderToCommodity> OrderToCommodities { get; set; }
    }
}
