using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp1.Contexts;

namespace WebApp1.Repositories
{
    public abstract class Repository<TEntity> where TEntity : class
    {
        private readonly IdentityContext _context;

        protected Repository(IdentityContext context)
        {
            _context = context;
        }

        //Create
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        //Get one
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            if (entity != null) 
                return entity;

            return null!;
        }

        //Get a list of
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        //Get all from a certain category for example
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).ToListAsync();
        }

        //Update new entity
        public virtual async Task<TEntity> UpdateAsync(TEntity entity) 
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;  
        }

        //Delete
        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            } catch { };

            return false;
        }
    }
}
