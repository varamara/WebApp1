using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid ArticleNumber { get; set; } = Guid.NewGuid(); 
        
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string? InStock { get; set; }

        public static implicit operator ProductModel(ProductEntity entity)
        {
            return new ProductModel
            {
                Id = entity.Id,
                Name = entity.Name,
                ArticleNumber = entity.ArticleNumber,
                Price = entity.Price,
                Category = entity.Category,
                InStock = entity.InStock

            };
        }
    }
}
