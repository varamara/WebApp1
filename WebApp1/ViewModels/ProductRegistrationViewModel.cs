using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp1.ViewModels
{
    public class ProductRegistrationViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Product Title *")]
        public string ProductName { get; set; } = null!;

        [Display(Name = "Description *")]
        public string? ProductDescription { get; set; }

        [Display(Name = "Image URL")]
        public string? ProductImage { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Product Price *")]
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Category *")]
        public int SelectedCategoryId { get; set; }

        public List<CategoryViewModel>? Categories { get; set; }
    }
}
