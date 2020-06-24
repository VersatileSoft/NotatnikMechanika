using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace NotatnikMechanika.Data.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual IEnumerable<Car> Cars { get; set; }
        public virtual IEnumerable<Customer> Customers { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
        public virtual IEnumerable<Service> Services { get; set; }
        public virtual IEnumerable<Commodity> Commodities { get; set; }
    }
}
