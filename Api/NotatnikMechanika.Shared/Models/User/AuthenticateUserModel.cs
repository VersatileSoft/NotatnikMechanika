using System.ComponentModel.DataAnnotations;

namespace NotatnikMechanika.Shared.Models.User
{
    public class AuthenticateUserModel
    {
        [Required(ErrorMessage = "Pole nazwa użytkownika nie może być puste. \r\n")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu E-mail.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Pole hasło nie może być puste &#10;")]
        public string Password { get; set; }
    }
}
