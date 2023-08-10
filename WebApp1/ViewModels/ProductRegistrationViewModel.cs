using System.ComponentModel.DataAnnotations;
using WebApp1.Models.Schemas;

namespace WebApp1.ViewModels;

public class ProductRegistrationViewModel
{
    public string ArticleNumber { get; } = Guid.NewGuid().ToString();
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

    [Display(Name = "Product Tag")]
    public List<string> Tags { get; set; } = new List<string>();

    [Display(Name = "Image URL")]
    public string? ProductImage { get; set; }


    public static implicit operator ProductSchema(ProductRegistrationViewModel viewModel)
    {
        return new ProductSchema
        {
            ArticleNumber = viewModel.ArticleNumber,
            ProductName = viewModel.ProductName,
            ProductDescription = viewModel.ProductDescription,
            ProductPrice = viewModel.ProductPrice,
            ProductCategoryId = viewModel.ProductCategoryId,
            Tags = viewModel.Tags,
            ProductImage = viewModel.ProductImage,
        };
    }
}
