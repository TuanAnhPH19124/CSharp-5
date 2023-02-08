using DAL.Base;
using System;

namespace DAL.Models
{
    public class TrangThai : IEntityBase
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
