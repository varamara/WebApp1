using System.ComponentModel.DataAnnotations;
using WebApp1.Models.Entities;

namespace WebApp1.ViewModels;

public class ContactFormViewModel
{
    public int Id { get; set; }

    [Display(Name = "Your Name*")]
    [RegularExpression(@"^[a-öA-Ö]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter a valid first name.")]
    [Required(ErrorMessage = "This field is required")]
    public string Name { get; set; } = null!;

    [Display(Name = "Your Email*")]
    [RegularExpression(@"^[a-zA-Z0-9. _%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter a valid e-mail.")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "This field is required")]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone Number (optional)")]
    [RegularExpression(@"^\+?[\d-]+[\d]+$", ErrorMessage = "Enter a valid phone number.")]
    public string? Mobile { get; set; }

    [Display(Name = "Company (optional)")]
    public string? Company { get; set; }

    [Display(Name = "Write Something")]
    [Required(ErrorMessage = "This field is required")]
    public string Message { get; set; } = null!;

    [Display(Name = "Save my name, email in this browser for the next time I comment. ")]
    public bool TermsAndConditions { get; set; } = false;


    public static implicit operator ContactFormEntity(ContactFormViewModel ViewModel)
    {
        return new ContactFormEntity
        {
            Name = ViewModel.Name,
            Mobile = ViewModel.Mobile,
            Company = ViewModel.Company,
            Email = ViewModel.Email,
            Message = ViewModel.Message,
        };
    }
}
