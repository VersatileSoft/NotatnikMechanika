using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NotatnikMechanika.Shared.Models.User
{
    public class AuthenticateUserModel
    {
        [Required(ErrorMessage = "Pole nazwa użytkownika nie może być puste.")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu E-mail.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Pole hasło nie może być puste")]
        public string Password { get; set; }
    }
}
