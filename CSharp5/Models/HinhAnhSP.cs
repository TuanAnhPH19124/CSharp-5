namespace CSharp5.Models
{
    public class HinhAnhSP
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public int Id_SPCT { get; set; }
        public SanPhamChiTiet sanPhamChiTiet { get; set; }

    }
}
