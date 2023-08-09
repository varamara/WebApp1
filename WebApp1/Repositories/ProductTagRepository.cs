using WebApp1.Contexts;
using WebApp1.Models.Entities;

namespace WebApp1.Repositories
{
    public class ProductTagRepository : Repository<ProductTagEntity>
    {
        public ProductTagRepository(IdentityDataContext context) : base(context)
        {
        }
    }
}
