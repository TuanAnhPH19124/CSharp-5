using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp5.Models
{
    public class NguoiDung
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool TrangThai { get; set; }
        public string SDT { get; set; }


        public int Id_phanquyen { get; set; }
        public PhanQuyen phanQuyen { get; set; }
        public List<DiaChi> diaChis { get; set; }
        public List<HoaDon> hoaDons { get; set; }
    }
}
