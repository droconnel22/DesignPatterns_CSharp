using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shipbob.Data.Context;


namespace Shipbob.Data.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
      
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using (var context = new InventoryContext())
            {
                return await context.Set<TEntity>().ToListAsync();
            }
        }

       
        public async Task<IEnumerable<TEntity>> GetSomeByCriteria(int InitialCount, Func<TEntity, bool> criteria)
        {
            using (var context = new InventoryContext())
            {
                return context.Set<TEntity>()
                    .Where(criteria)
                    .Take(InitialCount)
                    .ToList();
            }
        }

        // IQueryable is leaky abstracts, not best practice for async/await. Here for completeness.
        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new InventoryContext())
            {
                return context.Set<TEntity>().Where(predicate).AsQueryable();
            }
        }
      
        public async Task<bool> AddEntityAsync(TEntity entity)
        {
            if (entity == null) return false;
            using (var context = new InventoryContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.Set<TEntity>().Add(entity);
                await context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> UpdateEntityAsync(TEntity entity)
        {
            if (entity == null) return false;
            using (var context = new InventoryContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            return true;

        }

        public async Task<bool> RemoveEntityAsync(TEntity entity)
        {
            if (entity == null) return false;
            using (var context = new InventoryContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
            }
            return true;
        }      
    }
}