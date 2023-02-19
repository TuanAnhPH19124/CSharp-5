using DAL.Base;
using DAL.Data;
using DAL.IServices;
using DAL.Models;

namespace DAL.Services
{
    public class SanPhamService : EntityBaseRepository<SanPham>, ISanPhamService
    {
        public SanPhamService(DbContexts contexts) : base(contexts)
        {
        }
    }
}
