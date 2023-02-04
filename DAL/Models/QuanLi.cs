using System.Collections.Generic;

namespace DAL.Models
{
    public class QuanLi
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string Matkhau { get; set; }
        public bool TrangThai { get; set; }

        public int Id_phanquyen { get; set; }
        public PhanQuyen phanQuyen { get; set; }

        public List<TrangThai> trangThais { get; set; }

    }
}
