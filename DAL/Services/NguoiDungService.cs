using DAL.Base;
using DAL.Data;
using DAL.IServices;
using DAL.Models;

namespace DAL.Services
{
    public class NguoiDungService : EntityBaseRepository<NguoiDung>, INguoiDungService
    {
        public NguoiDungService(DbContexts contexts) : base(contexts)
        {
        }
    }
}
