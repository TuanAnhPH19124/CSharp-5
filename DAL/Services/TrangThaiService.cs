using DAL.Base;
using DAL.Data;
using DAL.IServices;
using DAL.Models;

namespace DAL.Services
{
    public class TrangThaiService : EntityBaseRepository<TrangThai>, ITrangThaiService
    {
        public TrangThaiService(DbContexts contexts) : base(contexts)
        {
        }
    }
}
