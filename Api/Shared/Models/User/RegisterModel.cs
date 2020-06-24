using System.ComponentModel.DataAnnotations;

namespace NotatnikMechanika.Shared.Models.User
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [EmailAddress(ErrorMessage = "Incorrect Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}