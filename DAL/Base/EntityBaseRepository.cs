using DAL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        public readonly DbContexts _contexts;
        public EntityBaseRepository(DbContexts contexts)
        {
            _contexts = contexts;
        }

        public async Task<ActionResult<IEnumerable<T>>> AddAsync(T entity)
        {
            await _contexts.Set<T>().AddAsync(entity);
            await _contexts.SaveChangesAsync();
            return await _contexts.Set<T>().ToListAsync();

        }

        public async Task<ActionResult> AddRangeAsync(List<T> entities)
        {
            await _contexts.Set<T>().AddRangeAsync(entities);
            await _contexts.SaveChangesAsync();
            return new OkResult();
        }

        public bool EntityExists(int id)
        {
            return _contexts.Set<T>().Any(x => x.Id == id);
        }

        public async Task<ActionResult<IEnumerable<T>>> GetAll2Async(IQueryable<T> query)
        {
            return await query.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<T>>> GetAllAsync()
        {
            var result = await _contexts.Set<T>().ToListAsync();
            return result;
        }

        public async Task<ActionResult<IEnumerable<T>>> GetAllAsync(params Expression<Func<T, object>>[] objectIncludes)
        {
            IQueryable<T> query = _contexts.Set<T>();
            query = objectIncludes.Aggregate(query, (current, objectIncludes) => current.Include(objectIncludes));
            return await query.ToListAsync();
        }



        public IQueryable<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
                                                             )
        {
            IQueryable<T> query = _contexts.Set<T>();


            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public async Task<ActionResult<T>> GetOneAsync(int id)
        {
            var result = await _contexts.Set<T>().FirstOrDefaultAsync(p => p.Id == id);
            return result;
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _contexts.Set<T>().FirstOrDefaultAsync(p => p.Id == id);
            EntityEntry entityEntry = _contexts.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _contexts.SaveChangesAsync();

        }

        public async Task RemoveRangeAsync(List<T> entities)
        {
            _contexts.Set<T>().RemoveRange(entities);
            await _contexts.SaveChangesAsync(); 
        }

        public async Task<ActionResult<IEnumerable<T>>> UpdateAsync(T entity)
        {
            EntityEntry entityEntry = _contexts.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _contexts.SaveChangesAsync();
            return await _contexts.Set<T>().ToListAsync();
        }
    }
}
