namespace CSharp5.Models
{
    public class NhaCungCap
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public int Id_SPCT { get; set; }
        public SanPhamChiTiet sanPhamChiTiet { get; set; }
    }
}
