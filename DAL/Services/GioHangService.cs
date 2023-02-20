using DAL.Base;
using DAL.Data;
using DAL.IServices;
using DAL.Models;

namespace DAL.Services
{
    public class GioHangService : EntityBaseRepository<GioHang>, IGioHangService
    {
        public GioHangService(DbContexts contexts) : base(contexts)
        {
        }
    }
}
