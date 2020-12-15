using PropertyChanged;
using System.ComponentModel.DataAnnotations;

namespace NotatnikMechanika.Shared.Models.Service
{
    [AddINotifyPropertyChangedInterface]
    public class ServiceModel : ValidateModelBase
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        
        public bool IsInOrder { get; set; }
        public bool Finished { get; set; }
    }
}
