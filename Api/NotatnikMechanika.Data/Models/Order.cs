﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace NotatnikMechanika.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateTime AcceptDate { get; set; }
        public DateTime FinishDate { get; set; }

        public virtual IEnumerable<OrderToCommodity> OrderToCommodities { get; set; }
        public virtual IEnumerable<OrderToService> OrderToServices { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }
}
