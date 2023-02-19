using DAL.Base;
using DAL.Data;
using DAL.IServices;
using DAL.Models;

namespace DAL.Services
{
    public class SanPhamChiTietService : EntityBaseRepository<SanPhamChiTiet>, ISanPhamChiTietService
    {
        public SanPhamChiTietService(DbContexts contexts) : base(contexts)
        {
        }
    }
}
