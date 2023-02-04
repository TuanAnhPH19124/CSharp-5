namespace CSharp5.Models
{
    public class GioHang
    {
        public int Id { get; set; }
        public int SoLuong { get; set; }
        public int Id_spct { get; set; }
        public SanPhamChiTiet sanPhamChiTiet { get; set; }
        public int Id_nguoidung { get; set; }
        public NguoiDung nguoiDung { get; set; }
    }
}
