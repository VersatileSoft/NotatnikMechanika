﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Data.Models
{
    public class OrderToCommodity
    {
        public int OrderId { get; set; }
        public int CommodityId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Commodity Commodity { get; set; }
    }
}
