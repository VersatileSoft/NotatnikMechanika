using System.ComponentModel.DataAnnotations;

namespace NotatnikMechanika.Shared.Models.Customer
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole imię jest wymagane")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole nazwisko jest wymagane")]
        public string Surname { get; set; }
        public string CompanyName { get; set; }
        /// <summary>
        /// np NIP
        /// </summary>
        public string CompanyIdentyficator { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
