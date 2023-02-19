using DAL.Base;
using DAL.Data;
using DAL.IServices;
using DAL.Models;

namespace DAL.Services
{
    public class GiamGiaHDService : EntityBaseRepository<GiamGiaHD>, IGiamGiaHDService
    {
        public GiamGiaHDService(DbContexts contexts) : base(contexts)
        {
        }
    }
}
