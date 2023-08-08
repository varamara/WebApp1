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

    public List<TagEntity> AvailableTags { get; set; } = new List<TagEntity>();
    public List<int> SelectedTagIds { get; set; } = new List<int>();
}
