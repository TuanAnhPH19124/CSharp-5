using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class NguoiDung : IEntityBase
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; }

        public List<DiaChi> diaChis { get; set; }
        public List<GioHang> gioHangs { get; set; }
    }
}
