using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class DbContexts : DbContext
    {
       
        public DbContexts()
        {

        }
        public DbContexts(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source =PHONGTT2710\SQLEXPRESS; Initial Catalog = csharp5-thucungshop; Integrated Security = True; Pooling=False"));

      
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiaChi>().HasOne(p => p.nguoiDung).WithMany(n => n.diaChis).HasForeignKey(p => p.Id_Nguoidung);
            modelBuilder.Entity<HoaDon>().HasOne(p => p.diaChi).WithMany(n => n.hoaDons).HasForeignKey(p => p.Id_diachi);
            modelBuilder.Entity<TrangThai>().HasOne(p => p.hoaDon).WithMany(n => n.trangThais).HasForeignKey(p => p.Id_hoadon);
            modelBuilder.Entity<TrangThai>().HasOne(p => p.quanLi).WithMany(n => n.trangThais).HasForeignKey(p => p.Id_quanli);
            modelBuilder.Entity<QuanLi>().HasOne(p => p.phanQuyen).WithMany(n => n.quanLis).HasForeignKey(p => p.Id_phanquyen);
            //modelBuilder.Entity<HoaDon>().HasOne(p => p.sanPhamChiTiet).WithMany(n => n.hoaDons).HasForeignKey(p => p.Id_spct);
            modelBuilder.Entity<HoaDonChiTiet>().HasOne(p => p.hoaDon).WithMany(n => n.hoaDonChiTiets).HasForeignKey(p => p.Id_hd);
            modelBuilder.Entity<HoaDonChiTiet>().HasOne(p => p.sanPhamChiTiet).WithMany(n => n.hoaDonChiTiets).HasForeignKey(p => p.Id_spct);
            modelBuilder.Entity<SanPhamChiTiet>().HasOne(p => p.sanPham).WithMany(n => n.sanPhamChiTiets).HasForeignKey(p => p.Id_SP);
            modelBuilder.Entity<SPCT_Mau>().HasKey(p => new { p.Id_mau, p.Id_spct });
            modelBuilder.Entity<SPCT_Mau>().HasOne(p => p.mau).WithMany(n => n.sPCT_Maus).HasForeignKey(p => p.Id_mau);
            modelBuilder.Entity<SPCT_Mau>().HasOne(p => p.sanPhamChiTiet).WithMany(n => n.sPCT_Maus).HasForeignKey(p => p.Id_spct);
            modelBuilder.Entity<HinhAnhSP>().HasOne(p => p.sanPhamChiTiet).WithMany(n => n.hinhAnhSPs).HasForeignKey(p => p.Id_SPCT);
            modelBuilder.Entity<Size>().HasOne(p => p.sanPhamChiTiet).WithMany(n => n.Sizes).HasForeignKey(p => p.Id_SPCT);
            modelBuilder.Entity<NhaCungCap>().HasOne(p => p.sanPhamChiTiet).WithMany(n => n.nhaCungCaps).HasForeignKey(p => p.Id_SPCT);
            modelBuilder.Entity<GioHang>().HasOne(p => p.nguoiDung).WithMany(n => n.gioHangs).HasForeignKey(p => p.Id_nguoidung);
            modelBuilder.Entity<GioHang>().HasOne(p => p.sanPhamChiTiet).WithMany(n => n.gioHangs).HasForeignKey(p => p.Id_spct);
            modelBuilder.Entity<HoaDon>().HasOne(p => p.giamGiaHD).WithMany(n => n.hoaDons).HasForeignKey(p => p.Id_GiamGia);
            modelBuilder.Entity<SanPhamChiTiet>().HasOne(p => p.giamGiaSP).WithMany(n => n.sanPhamChiTiets).HasForeignKey(p => p.Id_GiamGia);
        }

        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<DiaChi> diaChis { get; set; }
        public DbSet<HinhAnhSP> hinhAnhSPs { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }
        public DbSet<NhaCungCap> nhaCungCaps { get; set; }
        public DbSet<PhanQuyen> phanQuyens { get; set; }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<SanPhamChiTiet> sanPhamChiTiets { get; set; }
        public DbSet<Size> sizes { get; set; }
        public DbSet<TrangThai> trangThais { get; set; }
        public DbSet<QuanLi> quanLis { get; set; }
        public DbSet<Mau> maus { get; set; }
        public DbSet<SPCT_Mau> sPCT_Maus { get; set; }
        public DbSet<GioHang> gioHangs { get; set; }
        public DbSet<GiamGiaHD> giamGiaHDs { get; set; }
        public DbSet<GiamGiaSP> giamGiaSPs { get; set; }
        public DbSet<HoaDonChiTiet> hoaDonChiTiets { get; set; }
    }
}
