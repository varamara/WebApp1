using System.ComponentModel.DataAnnotations;
using WebApp1.Models.Entities;

namespace WebApp1.ViewModels;

public class RegisterViewModel
{

    
    [Display(Name = "First name")]
    [RegularExpression(@"^[a-öA-Ö]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter a valid first name.")]
    [Required(ErrorMessage = "This field is required")]
    
    public string FirstName { get; set; } = null!;



    [Display(Name = "Last name")]
    [RegularExpression(@"^[a-öA-Ö]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter a valid last name.")]
    [Required(ErrorMessage = "This field is required")]
    public string LastName { get; set; } = null!;



    [Display(Name = "Email")]
    [RegularExpression(@"^[a-zA-Z0-9. _%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter a valid email.")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "This field is required")]
    public string Email { get; set; } = null!;



    [Display(Name = "Password")]

    [RegularExpression(@"^?.*[A-Z](?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Enter a valid password.")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "This field is required")]
    public string Password { get; set; } = null!;



    [Display(Name = "Confirm password")]
    [Compare(nameof(Password), ErrorMessage = "The passwords do not match.")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "This field is required")]
    public string ConfirmPassword { get; set; } = null!;



 
    [Display(Name = "Street name")]
    public string? StreetName { get; set; }


    [Display(Name = "Postal code")]
    public string? PostalCode { get; set; }

    
    [Display(Name = "City")]
    public string? City { get; set; }


    public static implicit operator UserEntity(RegisterViewModel registerViewModel)
    {
        var userEntity = new UserEntity() { Email = registerViewModel.Email };
        userEntity.GenerateSecurepassword(registerViewModel.Password);
        return userEntity;  
    }

    public static implicit operator ProfileEntity(RegisterViewModel registerViewModel)
    {
        return new ProfileEntity
        {
            FirstName = registerViewModel.FirstName,
            LastName = registerViewModel.LastName,
            StreetName = registerViewModel.StreetName,
            PostalCode = registerViewModel.PostalCode,
            City = registerViewModel.City,
        };
    }
}
