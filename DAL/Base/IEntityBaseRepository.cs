using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<ActionResult<IEnumerable<T>>> GetAllAsync();
        Task<ActionResult<IEnumerable<T>>> GetAllAsync(params Expression<Func<T, object>>[] objectIncludes);
        Task<ActionResult<IEnumerable<T>>> GetAll2Async(IQueryable<T> query);
        Task<ActionResult<T>> GetOneAsync(int id);
        Task<ActionResult<IEnumerable<T>>> AddAsync(T entity);
        Task<ActionResult> AddRangeAsync(List<T> entities);
        Task<ActionResult<IEnumerable<T>>> UpdateAsync(T entity);
        Task RemoveAsync(int id);
        Task RemoveRangeAsync(List<T> entities);
        bool EntityExists(int id);
        IQueryable<T> GetFirstOrDefault(
                                          Expression<Func<T, bool>> predicate = null,
                                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
                                          );
    }
}
