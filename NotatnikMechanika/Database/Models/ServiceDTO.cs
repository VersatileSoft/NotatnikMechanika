using PropertyChanged;

namespace NotatnikMechanika.Database.Models
{
    [AddINotifyPropertyChangedInterface]
    public class ServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Selected { get; set; }
    }
}