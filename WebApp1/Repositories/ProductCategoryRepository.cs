using WebApp1.Contexts;
using WebApp1.Models.Entities;

namespace WebApp1.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategoryEntity>
    {
        public ProductCategoryRepository(IdentityContext context) : base(context)
        {
        }
    }
}
