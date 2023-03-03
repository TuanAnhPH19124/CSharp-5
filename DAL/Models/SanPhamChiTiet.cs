using DAL.Base;
using System.Collections.Generic;

namespace DAL.Models
{
    public class SanPhamChiTiet : IEntityBase
    {
        public int Id { get; set; }
        public string TenSP { get; set; }
        public string MoTa { get; set; }
        public double GiaNhap { get; set; }
        public double GianBan { get; set; }
        public int SoLuong { get; set; }
        public bool TrangThai { get; set; }

        public int Id_SP { get; set; }
        public SanPham sanPham { get; set; }

        public int? Id_GiamGia { get; set; }
        public GiamGiaSP giamGiaSP { get; set; }

        public List<HoaDonChiTiet> hoaDonChiTiets { get; set; }

        public List<HinhAnhSP> hinhAnhSPs { get; set; }
        public List<Size> Sizes { get; set; }
        public List<NhaCungCap> nhaCungCaps { get; set; }
        public List<SPCT_Mau> sPCT_Maus { get; set; }
        public List<GioHang> gioHangs { get; set; }

    }
}
