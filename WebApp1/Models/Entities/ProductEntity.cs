using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WebApp1.Models.Entities.ProductEntity;

namespace WebApp1.Models.Entities;

public class ProductEntity
{
    [Key]
    public string ArticleNumber { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string? ProductDescription { get; set; }

    [Column(TypeName = "money")]
    public decimal ProductPrice { get; set; }
    public int ProductCategoryId { get; set; }
    public string? ProductImage { get; set; }
    public ProductCategoryEntity ProductCategory { get; set; } = null!;
    public ICollection<ProductTagEntity> productTags { get; set; } = new HashSet<ProductTagEntity>();
}
