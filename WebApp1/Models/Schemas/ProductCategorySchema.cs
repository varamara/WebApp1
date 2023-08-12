using System.ComponentModel.DataAnnotations;
using WebApp1.Models.Entities;

namespace WebApp1.Models.Schemas
{
    public class ProductCategorySchema
    {
        [Required]
        [MinLength(2)]
        public string CategoryName { get; set; } = null!;


        public static implicit operator ProductCategoryEntity(ProductCategorySchema schema)
        {
            if (schema != null)
            {
                return new ProductCategoryEntity
                {
                    CategoryName = schema.CategoryName
                };
            }

            return null!;

        }
    }
}
