﻿using System.ComponentModel.DataAnnotations;

namespace NotatnikMechanika.Shared.Models.User
{
    public class CreateUserModel
    {
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}