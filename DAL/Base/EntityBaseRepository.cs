using DAL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<ActionResult<IEnumerable<T>>> GetAllAsync()
        {
            var result = await _contexts.Set<T>().ToListAsync();
            return result;
        }

        public async Task<ActionResult<T>> GetOneAsync(int id)
        {
            var result = await _contexts.Set<T>().FirstOrDefaultAsync(p => p.Id == id);
            return result;
        }

        public async Task<ActionResult<IEnumerable<T>>> RemoveAsync(int id)
        {
            var entity = await _contexts.Set<T>().FirstOrDefaultAsync(p => p.Id == id);
            EntityEntry entityEntry = _contexts.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _contexts.SaveChangesAsync();
            return await _contexts.Set<T>().ToListAsync();
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
