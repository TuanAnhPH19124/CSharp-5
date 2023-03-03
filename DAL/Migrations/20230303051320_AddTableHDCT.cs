using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddTableHDCT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hoaDons_sanPhamChiTiets_Id_spct",
                table: "hoaDons");

            migrationBuilder.DropIndex(
                name: "IX_hoaDons_Id_spct",
                table: "hoaDons");

            migrationBuilder.DropColumn(
                name: "GiaSP",
                table: "hoaDons");

            migrationBuilder.DropColumn(
                name: "Id_spct",
                table: "hoaDons");

            migrationBuilder.CreateTable(
                name: "hoaDonChiTiets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Id_hd = table.Column<int>(type: "int", nullable: false),
                    Id_spct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDonChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hoaDonChiTiets_hoaDons_Id_hd",
                        column: x => x.Id_hd,
                        principalTable: "hoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoaDonChiTiets_sanPhamChiTiets_Id_spct",
                        column: x => x.Id_spct,
                        principalTable: "sanPhamChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hoaDonChiTiets_Id_hd",
                table: "hoaDonChiTiets",
                column: "Id_hd");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDonChiTiets_Id_spct",
                table: "hoaDonChiTiets",
                column: "Id_spct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hoaDonChiTiets");

            migrationBuilder.AddColumn<double>(
                name: "GiaSP",
                table: "hoaDons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Id_spct",
                table: "hoaDons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_Id_spct",
                table: "hoaDons",
                column: "Id_spct");

            migrationBuilder.AddForeignKey(
                name: "FK_hoaDons_sanPhamChiTiets_Id_spct",
                table: "hoaDons",
                column: "Id_spct",
                principalTable: "sanPhamChiTiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
