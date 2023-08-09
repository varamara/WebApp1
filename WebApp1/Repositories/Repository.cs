using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        //Update
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        //Get one
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
                if (entity != null) 
                    return entity;
            }
            catch(Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        //Get a list of
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                var entities = await _context.Set<TEntity>().ToListAsync();
                if (entities != null)
                    return entities;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }


        //Get all from a certain category for example
        public virtual async Task<IEnumerable<TEntity>> GetAllWhereAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).ToListAsync();
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
