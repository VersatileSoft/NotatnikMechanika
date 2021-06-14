using System.ComponentModel.DataAnnotations;

namespace NotatnikMechanika.Shared.Models.User
{
    public class RegisterModel : ValidateModelBase
    {
        [Required(ErrorMessage = "Podaj hasło")]
        [StringLength(100, ErrorMessage = "Hasło musi mieć conajmniej {2} i najwięcej {1} znakow", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Potwierdź hasło")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła są różne")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Podaj imię")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Podaj nazwisko")]
        public string? Surname { get; set; }

        [EmailAddress(ErrorMessage = "Nieprawidłowy adres Email")]
        [Required(ErrorMessage = "Podaj adres Email")]
        public string? Email { get; set; }
    }
}