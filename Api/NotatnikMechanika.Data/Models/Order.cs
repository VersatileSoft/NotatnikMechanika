using System;
using System.Collections.Generic;

namespace NotatnikMechanika.Data.Models
{
    public class Order : EntityBase
    {
        public int CarId { get; set; }
        public string Details { get; set; }
        public DateTime AcceptDate { get; set; }
        public DateTime FinishDate { get; set; }

        public virtual IEnumerable<OrderToCommodity> OrderToCommodities { get; set; }
        public virtual IEnumerable<OrderToService> OrderToServices { get; set; }
        public virtual Car Car { get; set; }
    }
}
