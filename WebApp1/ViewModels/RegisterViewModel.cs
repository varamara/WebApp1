using System.ComponentModel.DataAnnotations;

namespace WebApp1.ViewModels
{
    public class RegisterViewModel
    {

        [Display(Name = "First name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last name")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [Display(Name = "Comnfirm password")]
        public string ConfirmPassword { get; set; } = null!;

     
        [Display(Name = "Street name")]
        public string? StreetName { get; set; }

        [Display(Name = "Postal code")]
        public string? PostalCode { get; set; }
        
        [Display(Name = "City")]
        public string? City { get; set; }
    }
}
