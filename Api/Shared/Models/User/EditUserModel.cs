using System.ComponentModel.DataAnnotations;

namespace NotatnikMechanika.Shared.Models.User
{
    public class EditUserModel : ValidateModelBase
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
