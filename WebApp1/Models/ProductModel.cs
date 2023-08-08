

namespace WebApp1.Models;

public class ProductModel
{
    public int? Id { get; set; }
    public string? ImageUrl { get; set; }
    public string? Name { get; set; }
    public Guid ArticleNumber { get; set; } 
    public decimal? Price { get; set; }
    public string? Category { get; set; }
    public string? InStock { get; set; }
}
