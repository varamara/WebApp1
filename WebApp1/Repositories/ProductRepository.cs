using System.Linq.Expressions;
using WebApp1.Contexts;
using WebApp1.Models.Entities;

namespace WebApp1.Repositories
{
    public class ProductRepository : Repository<ProductEntity>
    {
        private readonly IdentityContext _context;
        public ProductRepository(IdentityContext context) : base(context)
        {
        }
    }
}
