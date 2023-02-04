using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.IRepositories;
using DAL.Data;
using Microsoft.AspNetCore.Mvc;

namespace DAL.Repositories
{
    public class BaseRepositories<KEntities> : IBaseRepositories<KEntities> where KEntities : class
    {
        private readonly DbContexts _context;
        public BaseRepositories()
        {

        }
        public DbSet<KEntities> Entities { get; set; }
        DbSet<KEntities> IBaseRepositories<KEntities>.Entities { get; set; }
        public BaseRepositories(DbContexts context)
        {
            _context=context;
            //Entities= Entities;
        }


        public bool AddManyAsync(IEnumerable<KEntities> entities)
        {
            try
            {
                Entities.AddRange(entities);
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool AddOneAsync(KEntities entities)
        {
            try
            {
                Entities.Add(entities);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool DeleteManyAsync(IEnumerable<KEntities> entities)
        {
            try
            {
                Entities.RemoveRange(entities);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteOneAsync(KEntities entities)
        {
            try
            {
                Entities.Remove(entities);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ActionResult<IEnumerable<KEntities>>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<KEntities> GetOneAsync(IKey key)
        {
            return await Entities.FindAsync(key);
        }

        public bool UpdateManyAsync(IEnumerable<KEntities> entities)
        {
            try
            {
                Entities.UpdateRange(entities);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateOneAsync(KEntities entities)
        {
            try
            {
                Entities.Update(entities);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
