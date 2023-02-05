using System.Collections.Generic;

namespace DAL.Models
{
    public class SanPham
    {
        public int Id { get; set; }
        public string TheLoai { get; set; }
        public string DanhMuc { get; set; }

        public List<SanPhamChiTiet> sanPhamChiTiets { get; set; }
    }
}
