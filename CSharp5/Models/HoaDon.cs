using System;

namespace CSharp5.Models
{
    public class HoaDon
    {
        public int Id { get; set; }
        public DateTime NgayThanhToan { get; set; } = DateTime.Now;

        public string HinhThucThanhToan { get; set; }
        public string GhiChu { get; set; }
        public bool TrangThai { get; set; }

        public int Id_Nguoidung { get; set; }
        public NguoiDung nguoiDung { get; set; }

    }
}
