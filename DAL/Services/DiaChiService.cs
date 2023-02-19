using DAL.Base;
using DAL.Data;
using DAL.IServices;
using DAL.Models;

namespace DAL.Services
{
    public class DiaChiService : EntityBaseRepository<DiaChi>, IDiaChiService
    {
        public DiaChiService(DbContexts contexts) : base(contexts)
        {
        }
    }
}
