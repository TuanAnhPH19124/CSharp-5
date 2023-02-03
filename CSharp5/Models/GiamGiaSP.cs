using System;
using System.Collections.Generic;

namespace CSharp5.Models
{
    public class GiamGiaSP
    {
        public int Id { get; set; }
        public double GiaTri { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }

        public List<SanPhamChiTiet> sanPhamChiTiets { get; set; }
    }
}
