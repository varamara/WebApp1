using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string ProductName { get; set; } = null!;
    public string? ProductDescription { get; set; }
    public string? ProductImage { get; set; }

    [Column(TypeName = "money")]
    public decimal ProductPrice { get; set; }
    public int ProductCategoryId { get; set; }
    public ProductCategoryEntity ProductCategory { get; set; } = null!;
}

