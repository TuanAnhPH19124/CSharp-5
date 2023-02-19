using DAL.Base;
using DAL.Data;
using DAL.IServices;
using DAL.Models;

namespace DAL.Services
{
    public class PhanQuyenService : EntityBaseRepository<PhanQuyen>, IPhanQuyenService
    {
        public PhanQuyenService(DbContexts contexts) : base(contexts)
        {
        }
    }
}
