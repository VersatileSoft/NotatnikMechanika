using System;
using System.ComponentModel.DataAnnotations;

namespace NotatnikMechanika.Shared.Models.Order
{
    public class OrderModel : ValidateModelBase
    {
        public int Id { get; set; }
        [Required]
        public int CarId { get; set; }
        public string Details { get; set; }
        public DateTime AcceptDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
