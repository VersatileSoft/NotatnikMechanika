using System.Collections.Generic;

namespace NotatnikMechanika.Shared.Models.Order
{
    public class AddOrderModel : OrderModel
    {
        public IEnumerable<int> Services { get; set; }
        public IEnumerable<int> Commodities { get; set; }
    }
}
