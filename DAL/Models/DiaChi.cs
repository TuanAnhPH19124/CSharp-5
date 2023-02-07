using DAL.Base;
using System.Collections.Generic;

namespace DAL.Models
{
    public class DiaChi : IEntityBase
    {
        public int Id { get; set; }
        public string diachi { get; set; }
        public int Id_Nguoidung { get; set; }
        public NguoiDung nguoiDung { get; set; }
        public List<HoaDon> hoaDons { get; set; }
    }
}
