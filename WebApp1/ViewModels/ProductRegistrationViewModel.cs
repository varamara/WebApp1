using System.ComponentModel.DataAnnotations;
using WebApp1.Models.Entities;
using WebApp1.Models.Schemas;

namespace WebApp1.ViewModels;

public class ProductRegistrationViewModel
{

    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "Product Title *")]
    public string ProductName { get; set; } = null!;

    [Display(Name = "Description")]
    public string? ProductDescription { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "Product Price *")]
    [DataType(DataType.Currency)]
    public decimal ProductPrice { get; set; }

    [Display(Name = "Product Category *")]
    public int ProductCategoryId { get; set; }

    [Display(Name = "Image URL")]
    public string? ProductImage { get; set; }



    public List<TagEntity> AvailableTags { get; set; } = new List<TagEntity>();
    public List<int> SelectedTagIds { get; set; } = new List<int>();

    public static implicit operator ProductSchema(ProductRegistrationViewModel viewModel)
    {
        return new ProductSchema
        {
            ProductName = viewModel.ProductName,
            ProductDescription = viewModel.ProductDescription,
            ProductPrice = viewModel.ProductPrice,
            ProductCategoryId = viewModel.ProductCategoryId,
            ProductImage = viewModel.ProductImage,
        };
    }
}
