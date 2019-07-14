using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NotatnikMechanika.Shared.Models.User
{
    public class CreateUserModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
