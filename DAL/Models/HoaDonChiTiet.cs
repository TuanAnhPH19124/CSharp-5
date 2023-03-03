using DAL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class HoaDonChiTiet : IEntityBase
    {
        public int Id { get; set; }
        public int SoLuong { get; set; }
        public double Price { get; set; }

        public int Id_hd { get; set; }
        public HoaDon hoaDon { get; set; }

        public int Id_spct { get; set; }
        public SanPhamChiTiet sanPhamChiTiet { get; set; }
    }
}
