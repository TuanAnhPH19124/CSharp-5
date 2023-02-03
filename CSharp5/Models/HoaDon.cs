using System;
using System.Collections.Generic;

namespace CSharp5.Models
{
    public class HoaDon
    {
        public int Id { get; set; }
        public DateTime NgayThanhToan { get; set; } = DateTime.Now;
        public string HinhThucThanhToan { get; set; }
        public string GhiChu { get; set; }

        public int Id_diachi { get; set; }
        public DiaChi diaChi { get; set; }

        public double GiaSP { get; set; }
        public int Id_spct { get; set; }
        public SanPhamChiTiet sanPhamChiTiet { get; set; }

        public int Id_GiamGia { get; set; }
        public GiamGiaHD giamGiaHD { get; set; }

        public List<TrangThai> trangThais { get; set; }

        


    }
}
