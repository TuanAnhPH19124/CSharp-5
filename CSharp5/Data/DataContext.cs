using CSharp5.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp5.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NguoiDung>().HasOne(p => p.phanQuyen).WithMany(n => n.nguoiDungs).HasForeignKey(n => n.Id_phanquyen);
            modelBuilder.Entity<DiaChi>().HasOne(p => p.nguoiDung).WithMany(n => n.diaChis).HasForeignKey(p => p.Id_Nguoidung);
            modelBuilder.Entity<HoaDon>().HasOne(p => p.nguoiDung).WithMany(n => n.hoaDons).HasForeignKey(p => p.Id_Nguoidung);
        }

        public DbSet<NguoiDung> NguoiDungs { get; set; }
    }
}
