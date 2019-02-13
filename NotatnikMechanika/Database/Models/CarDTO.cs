using PropertyChanged;

namespace NotatnikMechanika.Database.Models
{
    [AddINotifyPropertyChangedInterface]
    public class CarDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public string Engine { get; set; }
        public string Power { get; set; }
        public string Course { get; set; }
        public string ProductionYear { get; set; }
    }
}