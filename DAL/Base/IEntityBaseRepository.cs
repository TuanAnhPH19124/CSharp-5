using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<ActionResult<IEnumerable<T>>> GetAllAsync();
        Task<ActionResult<T>> GetOneAsync(int id);
        Task<ActionResult<IEnumerable<T>>> AddAsync(T entity);
        Task<ActionResult<IEnumerable<T>>> UpdateAsync(T entity);
        Task RemoveAsync(int id);
        bool EntityExists(int id);
    }
}
