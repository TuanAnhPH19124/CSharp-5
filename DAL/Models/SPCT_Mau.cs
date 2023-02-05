namespace DAL.Models
{
    public class SPCT_Mau
    {
        public int Id_mau { get; set; }
        public Mau mau { get; set; }
        public int Id_spct { get; set; }
        public SanPhamChiTiet sanPhamChiTiet { get; set; }
    }
}
