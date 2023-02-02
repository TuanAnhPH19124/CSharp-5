using CSharp5.Data;
using CSharp5.IRepositories;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp5.Repositories
{
    public class AllRepositories<KEntities> : IAllRepositories<KEntities> where KEntities : class
    {
        private readonly DataContext _context;
        public AllRepositories()
        {

        }
        public DbSet<KEntities> Entities { get; set; }
        DbSet<KEntities> IAllRepositories<KEntities>.Entities { get; set; }
        public AllRepositories(DataContext context)
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

        public async Task<IEnumerable<KEntities>> GetAllAsync()
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
