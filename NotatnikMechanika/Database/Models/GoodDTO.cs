using PropertyChanged;

namespace NotatnikMechanika.Database.Models
{
    [AddINotifyPropertyChangedInterface]
    public class GoodDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public string Symbol { get; set; }
        public bool Selected { get; set; }
    }
}