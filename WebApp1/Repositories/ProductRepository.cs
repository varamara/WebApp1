using System.Linq.Expressions;
using WebApp1.Contexts;
using WebApp1.Models.Entities;

namespace WebApp1.Repositories
{
    public class ProductRepository : Repository<ProductEntity>
    {
        public ProductRepository(IdentityDataContext context) : base(context)
        {
        }
    }
}
