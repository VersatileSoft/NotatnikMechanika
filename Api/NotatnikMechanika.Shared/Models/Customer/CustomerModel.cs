namespace NotatnikMechanika.Shared.Models.Customer
{
    public class CustomerModel
    {
        public string Name { get; set; }
        public string SureName { get; set; }
        public string CompanyName { get; set; }
        /// <summary>
        /// np NIP
        /// </summary>
        public string CompanyIdentyficator { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
