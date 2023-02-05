namespace DAL.Models
{
    public class Size
    {
        public int Id { get; set; }
        public int size { get; set; }
        public int Id_SPCT { get; set; }
        public SanPhamChiTiet sanPhamChiTiet { get; set; }
    }
}
