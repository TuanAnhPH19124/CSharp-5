using DAL.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class SanPhamChiTiet : IEntityBase
    {
        public int Id { get; set; }
        public string TenSP { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        public string MoTa { get; set; }
        [Required(ErrorMessage = "Mô tả không được để trống")]
        public double GiaNhap { get; set; }
        [Required(ErrorMessage = "giá nhập không được để trống")]
        public double GianBan { get; set; }
        [Required(ErrorMessage = "giá bán không được để trống")]
        public int SoLuong { get; set; }
        [Required(ErrorMessage = "Số lượng không được để trống")]
        public bool TrangThai { get; set; }
        [Required(ErrorMessage = "Trạng thái không được để trống")]

        public int Id_SP { get; set; }
        public SanPham sanPham { get; set; }

        public int? Id_GiamGia { get; set; }
        public GiamGiaSP giamGiaSP { get; set; }

        public List<HoaDon> hoaDons { get; set; }

        public List<HinhAnhSP> hinhAnhSPs { get; set; }
        public List<Size> Sizes { get; set; }
        public List<NhaCungCap> nhaCungCaps { get; set; }
        [Required(ErrorMessage = "Nhà cung cấp không được để trống")]
        public List<SPCT_Mau> sPCT_Maus { get; set; }
        public List<GioHang> gioHangs { get; set; }

    }
}
