using System;

namespace CSharp5.Models
{
    public class TrangThai
    {
        public int Id { get; set; }
        public DateTime NgayThang { get; set; }
        public TimeSpan Gio { get; set; }
        public string MoTa { get; set; }

        public int Id_hoadon { get; set; }
        public HoaDon hoaDon { get; set; }

        public int Id_quanli { get; set; }
        public QuanLi quanLi { get; set; }
    }
}
