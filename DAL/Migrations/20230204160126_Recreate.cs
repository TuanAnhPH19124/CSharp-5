using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Recreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "giamGiaHDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaTri = table.Column<double>(type: "float", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KhongGioiHan = table.Column<bool>(type: "bit", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_giamGiaHDs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "giamGiaSPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiaTri = table.Column<double>(type: "float", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_giamGiaSPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "maus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaRGB = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "phanQuyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phanQuyens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "diaChis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Nguoidung = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diaChis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_diaChis_NguoiDungs_Id_Nguoidung",
                        column: x => x.Id_Nguoidung,
                        principalTable: "NguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quanLis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matkhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    Id_phanquyen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quanLis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quanLis_phanQuyens_Id_phanquyen",
                        column: x => x.Id_phanquyen,
                        principalTable: "phanQuyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sanPhamChiTiets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaNhap = table.Column<double>(type: "float", nullable: false),
                    GianBan = table.Column<double>(type: "float", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    Id_SP = table.Column<int>(type: "int", nullable: false),
                    Id_GiamGia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanPhamChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sanPhamChiTiets_giamGiaSPs_Id_GiamGia",
                        column: x => x.Id_GiamGia,
                        principalTable: "giamGiaSPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sanPhamChiTiets_sanPhams_Id_SP",
                        column: x => x.Id_SP,
                        principalTable: "sanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gioHangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Id_spct = table.Column<int>(type: "int", nullable: false),
                    Id_nguoidung = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gioHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gioHangs_NguoiDungs_Id_nguoidung",
                        column: x => x.Id_nguoidung,
                        principalTable: "NguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gioHangs_sanPhamChiTiets_Id_spct",
                        column: x => x.Id_spct,
                        principalTable: "sanPhamChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hinhAnhSPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_SPCT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hinhAnhSPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hinhAnhSPs_sanPhamChiTiets_Id_SPCT",
                        column: x => x.Id_SPCT,
                        principalTable: "sanPhamChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hoaDons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HinhThucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_diachi = table.Column<int>(type: "int", nullable: false),
                    GiaSP = table.Column<double>(type: "float", nullable: false),
                    Id_spct = table.Column<int>(type: "int", nullable: false),
                    Id_GiamGia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hoaDons_diaChis_Id_diachi",
                        column: x => x.Id_diachi,
                        principalTable: "diaChis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoaDons_giamGiaHDs_Id_GiamGia",
                        column: x => x.Id_GiamGia,
                        principalTable: "giamGiaHDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoaDons_sanPhamChiTiets_Id_spct",
                        column: x => x.Id_spct,
                        principalTable: "sanPhamChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nhaCungCaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_SPCT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhaCungCaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nhaCungCaps_sanPhamChiTiets_Id_SPCT",
                        column: x => x.Id_SPCT,
                        principalTable: "sanPhamChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    size = table.Column<int>(type: "int", nullable: false),
                    Id_SPCT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sizes_sanPhamChiTiets_Id_SPCT",
                        column: x => x.Id_SPCT,
                        principalTable: "sanPhamChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sPCT_Maus",
                columns: table => new
                {
                    Id_mau = table.Column<int>(type: "int", nullable: false),
                    Id_spct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sPCT_Maus", x => new { x.Id_mau, x.Id_spct });
                    table.ForeignKey(
                        name: "FK_sPCT_Maus_maus_Id_mau",
                        column: x => x.Id_mau,
                        principalTable: "maus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sPCT_Maus_sanPhamChiTiets_Id_spct",
                        column: x => x.Id_spct,
                        principalTable: "sanPhamChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trangThais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayThang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gio = table.Column<TimeSpan>(type: "time", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_hoadon = table.Column<int>(type: "int", nullable: false),
                    Id_quanli = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trangThais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trangThais_hoaDons_Id_hoadon",
                        column: x => x.Id_hoadon,
                        principalTable: "hoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trangThais_quanLis_Id_quanli",
                        column: x => x.Id_quanli,
                        principalTable: "quanLis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_diaChis_Id_Nguoidung",
                table: "diaChis",
                column: "Id_Nguoidung");

            migrationBuilder.CreateIndex(
                name: "IX_gioHangs_Id_nguoidung",
                table: "gioHangs",
                column: "Id_nguoidung");

            migrationBuilder.CreateIndex(
                name: "IX_gioHangs_Id_spct",
                table: "gioHangs",
                column: "Id_spct");

            migrationBuilder.CreateIndex(
                name: "IX_hinhAnhSPs_Id_SPCT",
                table: "hinhAnhSPs",
                column: "Id_SPCT");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_Id_diachi",
                table: "hoaDons",
                column: "Id_diachi");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_Id_GiamGia",
                table: "hoaDons",
                column: "Id_GiamGia");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_Id_spct",
                table: "hoaDons",
                column: "Id_spct");

            migrationBuilder.CreateIndex(
                name: "IX_nhaCungCaps_Id_SPCT",
                table: "nhaCungCaps",
                column: "Id_SPCT");

            migrationBuilder.CreateIndex(
                name: "IX_quanLis_Id_phanquyen",
                table: "quanLis",
                column: "Id_phanquyen");

            migrationBuilder.CreateIndex(
                name: "IX_sanPhamChiTiets_Id_GiamGia",
                table: "sanPhamChiTiets",
                column: "Id_GiamGia");

            migrationBuilder.CreateIndex(
                name: "IX_sanPhamChiTiets_Id_SP",
                table: "sanPhamChiTiets",
                column: "Id_SP");

            migrationBuilder.CreateIndex(
                name: "IX_sizes_Id_SPCT",
                table: "sizes",
                column: "Id_SPCT");

            migrationBuilder.CreateIndex(
                name: "IX_sPCT_Maus_Id_spct",
                table: "sPCT_Maus",
                column: "Id_spct");

            migrationBuilder.CreateIndex(
                name: "IX_trangThais_Id_hoadon",
                table: "trangThais",
                column: "Id_hoadon");

            migrationBuilder.CreateIndex(
                name: "IX_trangThais_Id_quanli",
                table: "trangThais",
                column: "Id_quanli");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gioHangs");

            migrationBuilder.DropTable(
                name: "hinhAnhSPs");

            migrationBuilder.DropTable(
                name: "nhaCungCaps");

            migrationBuilder.DropTable(
                name: "sizes");

            migrationBuilder.DropTable(
                name: "sPCT_Maus");

            migrationBuilder.DropTable(
                name: "trangThais");

            migrationBuilder.DropTable(
                name: "maus");

            migrationBuilder.DropTable(
                name: "hoaDons");

            migrationBuilder.DropTable(
                name: "quanLis");

            migrationBuilder.DropTable(
                name: "diaChis");

            migrationBuilder.DropTable(
                name: "giamGiaHDs");

            migrationBuilder.DropTable(
                name: "sanPhamChiTiets");

            migrationBuilder.DropTable(
                name: "phanQuyens");

            migrationBuilder.DropTable(
                name: "NguoiDungs");

            migrationBuilder.DropTable(
                name: "giamGiaSPs");

            migrationBuilder.DropTable(
                name: "sanPhams");
        }
    }
}
