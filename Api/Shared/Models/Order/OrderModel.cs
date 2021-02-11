using System;
using System.ComponentModel.DataAnnotations;

namespace NotatnikMechanika.Shared.Models.Order
{
    public class OrderModel : ValidateModelBase
    {
        public int Id { get; set; }
        public bool Archived { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Wybierz samochód")]
        public int CarId { get; set; }
        public string Details { get; set; }
        public DateTime AcceptDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
