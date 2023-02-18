using DAL.Base;
using DAL.Data;
using DAL.IServices;
using DAL.Models;

namespace DAL.Services
{
    public class GiamGiaSPService : EntityBaseRepository<GiamGiaSP>, IGiamGiaSPService
    {
        public GiamGiaSPService(DbContexts contexts) : base(contexts)
        {
        }
    }
}
