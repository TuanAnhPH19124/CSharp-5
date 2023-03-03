using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class HoaDon : IEntityBase
    {
        public int Id { get; set; }
        public DateTime NgayThanhToan { get; set; } = DateTime.Now;
        public string HinhThucThanhToan { get; set; }
        public string GhiChu { get; set; }

        public int Id_diachi { get; set; }
        public DiaChi diaChi { get; set; }

        public int? Id_GiamGia { get; set; }
        public GiamGiaHD giamGiaHD { get; set; }

        public List<TrangThai> trangThais { get; set; }
        public List<HoaDonChiTiet> hoaDonChiTiets { get; set; }



    }
}
