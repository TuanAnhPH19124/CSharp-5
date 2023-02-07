using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class GiamGiaHD : IEntityBase
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ChuongTrinh { get; set; }
        public double GiaTri { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public bool KhongGioiHan { get; set; }
        public int SoLuong { get; set; }

        public List<HoaDon> hoaDons { get; set; }
    }
}
