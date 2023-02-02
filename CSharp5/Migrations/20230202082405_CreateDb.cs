using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp5.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Id_phanquyen = table.Column<int>(type: "int", nullable: false),
                    phanQuyenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quanLis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quanLis_phanQuyens_phanQuyenId",
                        column: x => x.phanQuyenId,
                        principalTable: "phanQuyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    sanPhamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanPhamChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sanPhamChiTiets_sanPhams_sanPhamId",
                        column: x => x.sanPhamId,
                        principalTable: "sanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hinhAnhSPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_SPCT = table.Column<int>(type: "int", nullable: false),
                    sanPhamChiTietId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hinhAnhSPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hinhAnhSPs_sanPhamChiTiets_sanPhamChiTietId",
                        column: x => x.sanPhamChiTietId,
                        principalTable: "sanPhamChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Id_spct = table.Column<int>(type: "int", nullable: false),
                    sanPhamChiTietId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_hoaDons_sanPhamChiTiets_sanPhamChiTietId",
                        column: x => x.sanPhamChiTietId,
                        principalTable: "sanPhamChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nhaCungCaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_SPCT = table.Column<int>(type: "int", nullable: false),
                    sanPhamChiTietId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhaCungCaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nhaCungCaps_sanPhamChiTiets_sanPhamChiTietId",
                        column: x => x.sanPhamChiTietId,
                        principalTable: "sanPhamChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    size = table.Column<int>(type: "int", nullable: false),
                    Id_SPCT = table.Column<int>(type: "int", nullable: false),
                    sanPhamChiTietId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sizes_sanPhamChiTiets_sanPhamChiTietId",
                        column: x => x.sanPhamChiTietId,
                        principalTable: "sanPhamChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Id_quanli = table.Column<int>(type: "int", nullable: false),
                    quanLiId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_trangThais_quanLis_quanLiId",
                        column: x => x.quanLiId,
                        principalTable: "quanLis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_diaChis_Id_Nguoidung",
                table: "diaChis",
                column: "Id_Nguoidung");

            migrationBuilder.CreateIndex(
                name: "IX_hinhAnhSPs_sanPhamChiTietId",
                table: "hinhAnhSPs",
                column: "sanPhamChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_Id_diachi",
                table: "hoaDons",
                column: "Id_diachi");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_sanPhamChiTietId",
                table: "hoaDons",
                column: "sanPhamChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_nhaCungCaps_sanPhamChiTietId",
                table: "nhaCungCaps",
                column: "sanPhamChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_quanLis_phanQuyenId",
                table: "quanLis",
                column: "phanQuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_sanPhamChiTiets_sanPhamId",
                table: "sanPhamChiTiets",
                column: "sanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_sizes_sanPhamChiTietId",
                table: "sizes",
                column: "sanPhamChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_trangThais_Id_hoadon",
                table: "trangThais",
                column: "Id_hoadon");

            migrationBuilder.CreateIndex(
                name: "IX_trangThais_quanLiId",
                table: "trangThais",
                column: "quanLiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hinhAnhSPs");

            migrationBuilder.DropTable(
                name: "nhaCungCaps");

            migrationBuilder.DropTable(
                name: "sizes");

            migrationBuilder.DropTable(
                name: "trangThais");

            migrationBuilder.DropTable(
                name: "hoaDons");

            migrationBuilder.DropTable(
                name: "quanLis");

            migrationBuilder.DropTable(
                name: "diaChis");

            migrationBuilder.DropTable(
                name: "sanPhamChiTiets");

            migrationBuilder.DropTable(
                name: "phanQuyens");

            migrationBuilder.DropTable(
                name: "NguoiDungs");

            migrationBuilder.DropTable(
                name: "sanPhams");
        }
    }
}
