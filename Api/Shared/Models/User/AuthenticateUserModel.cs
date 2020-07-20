using System.ComponentModel.DataAnnotations;

namespace NotatnikMechanika.Shared.Models.User
{
    public class LoginModel : ValidateModelBase
    {
        [Required(ErrorMessage = "Pole email nie może być puste.")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu E-mail.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Pole hasło nie może być puste.")]
        public string Password { get; set; }
    }
}
