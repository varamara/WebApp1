using System.ComponentModel.DataAnnotations;
using WebApp1.Models.Entities;

namespace WebApp1.ViewModels;

public class ProductRegistrationViewModel
{

    [Required(ErrorMessage = "This field is required")]
    [Display(Name= "Product Name *")]
    public string Name { get; set; } = null!;


    [Display(Name = "description (optional)")]
    public string? Description { get; set; }


    [Required(ErrorMessage = "This field is required")]
    [Display(Name= "Product Price *")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }



    public static implicit operator ProductEntity(ProductRegistrationViewModel productRegistrationViewModel)
    {
        return new ProductEntity
        {
            Name = productRegistrationViewModel.Name,
            Description = productRegistrationViewModel.Description,
            Price = productRegistrationViewModel.Price
        };
    }
}
