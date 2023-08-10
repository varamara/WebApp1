using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp1.Contexts;
using WebApp1.Models.Entities;

namespace WebApp1.Repositories
{
    public class ProductRepository : Repository<ProductEntity>
    {
        private readonly IdentityDataContext _context;

        public ProductRepository(IdentityDataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            var entity = await _context.Products
                .Include(x => x.ProductCategory)
                .Include(x => x.ProductTags)
                .ThenInclude(x => x.Tag)
                .FirstOrDefaultAsync(expression);
            if (entity != null)
                return entity!;

            return null!;
        }

        public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _context.Products
                .Include(x => x.ProductCategory)
                .Include(x => x.ProductTags)
                .ThenInclude(x => x.Tag)
                .ToListAsync();
        }
    }
}
