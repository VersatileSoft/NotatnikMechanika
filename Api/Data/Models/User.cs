using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace NotatnikMechanika.Data.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Commodity> Commodities { get; set; }
    }
}
