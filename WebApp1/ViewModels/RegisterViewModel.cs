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


    [Display(Name = "Street name")]
    [RegularExpression(@"^[a-öA-Ö]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter a valid street name.")]
    [Required(ErrorMessage = "This field is required")]
    public string StreetName { get; set; } = null!;


    [Display(Name = "Postal code")]
    [Required(ErrorMessage = "This field is required")]
    public string PostalCode { get; set; } = null!;


    [Display(Name = "City")]
    [RegularExpression(@"^[a-öA-Ö]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter a valid city name.")]
    [Required(ErrorMessage = "This field is required")]
    public string City { get; set; } = null!;


    [Display(Name = "Mobile")]
    [RegularExpression(@"^\+?[\d-]+[\d]+$", ErrorMessage = "Enter a valid phone number.")]
    public string? Mobile { get; set; }


    [Display(Name = "Company")]
    public string? Company { get; set; }


    [Display(Name = "Email")]
    [RegularExpression(@"^[a-zA-Z0-9. _%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter a valid e-mail.")]
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


    [Display(Name = "Upload Profile Image")]
    [DataType(DataType.Upload)]
    public IFormFile? ProfileImage { get; set; }


    [Display(Name = "I have read and accept the terms and conditions")]
    [Required(ErrorMessage = "You must agree to the terms and conditions.")]
    public bool TermsAndConditions { get; set; } = false;


    
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

    public static implicit operator AddressEntity(RegisterViewModel registerViewModel)
    {
        return new AddressEntity
        {
            StreetName = registerViewModel.StreetName,
            PostalCode = registerViewModel.PostalCode,
            City = registerViewModel.City,
        };
    }
}
