using System;
using System.Collections.Generic;

namespace NotatnikMechanika.Api.Data.Models
{
    public class Order : EntityBase
    {
        public int CarId { get; set; }
        public string Details { get; set; }
        public bool Archived { get; set; } = false;
        public DateTime AcceptDate { get; set; }
        public DateTime FinishDate { get; set; }

        public virtual ICollection<OrderToCommodity> OrderToCommodities { get; set; }
        public virtual ICollection<Commodity> Commodities { get; set; }
        public virtual ICollection<OrderToService> OrderToServices { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual Car Car { get; set; }
    }
}
