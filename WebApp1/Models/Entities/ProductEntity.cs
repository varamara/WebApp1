using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }
    public ProductCategoryEntity ProductCategory { get; set; } = null!;
}
