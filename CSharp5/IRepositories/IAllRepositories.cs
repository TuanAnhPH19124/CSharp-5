using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp5.IRepositories
{
    public interface IAllRepositories<TEntities> where TEntities : class
    {
        DbSet<TEntities> Entities { get; set; }
        Task<IEnumerable<TEntities>> GetAllAsync();
        Task<TEntities> GetOneAsync(IKey key);
        bool AddOneAsync(TEntities entities);
        bool AddManyAsync(IEnumerable<TEntities> entities);
        bool DeleteOneAsync(TEntities entities);
        bool DeleteManyAsync(IEnumerable<TEntities> entities);
        bool UpdateOneAsync(TEntities entities);
        bool UpdateManyAsync(IEnumerable<TEntities> entities);

    }
}
