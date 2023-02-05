using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DAL.IRepositories
{
    public interface IBaseRepositories<TEntities> where TEntities : class
    {
        DbSet<TEntities> Entities { get; set; }
        Task<ActionResult<IEnumerable<TEntities>>> GetAllAsync();
        Task<TEntities> GetOneAsync(IKey key);
        bool AddOneAsync(TEntities entities);
        bool AddManyAsync(IEnumerable<TEntities> entities);
        bool DeleteOneAsync(TEntities entities);
        bool DeleteManyAsync(IEnumerable<TEntities> entities);
        bool UpdateOneAsync(TEntities entities);
        bool UpdateManyAsync(IEnumerable<TEntities> entities);

    }
}
