using DAL.Base;
using DAL.Data;
using DAL.IServices;
using DAL.Models;

namespace DAL.Services
{
    public class QuanLiService : EntityBaseRepository<QuanLi>, IQuanLiService
    {
        public QuanLiService(DbContexts contexts) : base(contexts)
        {
        }
    }
}
