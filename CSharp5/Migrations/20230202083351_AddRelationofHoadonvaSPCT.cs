using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp5.Migrations
{
    public partial class AddRelationofHoadonvaSPCT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hoaDons_sanPhamChiTiets_sanPhamChiTietId",
                table: "hoaDons");

            migrationBuilder.DropIndex(
                name: "IX_hoaDons_sanPhamChiTietId",
                table: "hoaDons");

            migrationBuilder.DropColumn(
                name: "sanPhamChiTietId",
                table: "hoaDons");

            migrationBuilder.AddColumn<double>(
                name: "GiaSP",
                table: "hoaDons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "sanPhamChiTietId",
                table: "hoaDons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_sanPhamChiTietId",
                table: "hoaDons",
                column: "sanPhamChiTietId");

            migrationBuilder.AddForeignKey(
                name: "FK_hoaDons_sanPhamChiTiets_sanPhamChiTietId",
                table: "hoaDons",
                column: "sanPhamChiTietId",
                principalTable: "sanPhamChiTiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
