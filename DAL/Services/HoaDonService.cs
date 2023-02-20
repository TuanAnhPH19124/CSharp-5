using DAL.Base;
using DAL.Data;
using DAL.IServices;
using DAL.Models;

namespace DAL.Services
{
    public class HoaDonService : EntityBaseRepository<HoaDon>, IHoaDonService
    {
        public HoaDonService(DbContexts contexts) : base(contexts)
        {
        }
    }
}
