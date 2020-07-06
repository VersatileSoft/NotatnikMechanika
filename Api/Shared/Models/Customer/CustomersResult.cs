using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Shared.Models.Customer
{
    public class CustomersResult : ResultBase
    {
        public IEnumerable<CustomerModel> Customers { get; set; }
    }
}
