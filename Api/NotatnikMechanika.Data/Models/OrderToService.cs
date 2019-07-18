using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Data.Models
{
    public class OrderToService
    {
        public int OrderId { get; set; }
        public int ServiceId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Service Service { get; set; }
    }
}
