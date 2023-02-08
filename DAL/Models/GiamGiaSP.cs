using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class GiamGiaSP : IEntityBase
    {
        public int Id { get; set; }
        public double GiaTri { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }

        public List<SanPhamChiTiet> sanPhamChiTiets { get; set; }
    }
}
