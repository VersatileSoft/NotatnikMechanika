using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Shared.Models.Order
{
    public class AllExtendedOrdersResult : ResultBase
    {
        public IEnumerable<OrderExtendedModel> Orders { get; set; }
    }
}
