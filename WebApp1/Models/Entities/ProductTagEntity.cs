using Microsoft.EntityFrameworkCore;

namespace WebApp1.Models.Entities;

[PrimaryKey("ProductId", "TagId")]
public class ProductTagEntity
{
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public int TagId { get; set; }
    public TagEntity Tag { get; set; } = null!;
}
