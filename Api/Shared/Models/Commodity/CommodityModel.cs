using PropertyChanged;
using System.ComponentModel.DataAnnotations;

namespace NotatnikMechanika.Shared.Models.Commodity
{
    [AddINotifyPropertyChangedInterface]
    public class CommodityModel : ValidateModelBase
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
        public bool Finished { get; set; }
    }
}
