﻿using System.Collections.Generic;

namespace NotatnikMechanika.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string HashedPassword { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public byte[] Salt { get; set; }

        public virtual IEnumerable<Car> Cars { get; set; }
        public virtual IEnumerable<Customer> Customers { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
        public virtual IEnumerable<Service> Services { get; set; }
        public virtual IEnumerable<Commodity> Commodities { get; set; }
    }
}
