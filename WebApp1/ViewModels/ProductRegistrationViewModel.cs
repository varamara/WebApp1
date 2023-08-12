using System.ComponentModel.DataAnnotations;
using WebApp1.Models.Entities;

namespace WebApp1.ViewModels;

public class ProductRegistrationViewModel
{

    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "Product Title *")]
    public string Title { get; set; } = null!;

    [Display(Name = "Description *")]
    public string? Description { get; set; }

    [Display(Name = "Image URL")]
    public string? ImageUrl { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "Product Price *")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "Category *")]
    public int SelectedCategoryId { get; set; }  // Används för att lagra vald kategori-ID

    public List<ProductCategoryEntity> Categories { get; set; } // Lista med tillgängliga kategorier

}
