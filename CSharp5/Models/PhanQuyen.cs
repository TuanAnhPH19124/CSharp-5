using System.Collections.Generic;

namespace CSharp5.Models
{
    public class PhanQuyen
    {
        public int Id { get; set; }
        public string Ten { get; set; }

        public List<QuanLi> quanLis { get; set; }

    }
}
