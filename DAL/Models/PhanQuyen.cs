using DAL.Base;
using System.Collections.Generic;

namespace DAL.Models
{
    public class PhanQuyen : IEntityBase
    {
        public int Id { get; set; }
        public string Ten { get; set; }

        public List<QuanLi> quanLis { get; set; }

    }
}
