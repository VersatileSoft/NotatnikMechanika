using System.Collections.Generic;

namespace NotatnikMechanika.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public string CompanyName { get; set; }
        /// <summary>
        /// np NIP
        /// </summary>
        public string CompanyIdentyficator { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }

        public virtual IEnumerable<Car> Cars { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
        public virtual User User { get; set; }
    }
}
