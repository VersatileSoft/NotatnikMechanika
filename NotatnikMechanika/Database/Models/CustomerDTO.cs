using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Database.Models
{
    [AddINotifyPropertyChangedInterface]
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Nip { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
