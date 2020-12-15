using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Shared.Models.Order
{
    public class AddOrderModel : OrderModel
    {
        public IEnumerable<int> Services { get; set; }
        public IEnumerable<int> Commodities { get; set; }
    }
}
