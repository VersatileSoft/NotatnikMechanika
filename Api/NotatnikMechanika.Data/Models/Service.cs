using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Data.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual IEnumerable<OrderToService> OrderToServices { get; set; }
    }
}
