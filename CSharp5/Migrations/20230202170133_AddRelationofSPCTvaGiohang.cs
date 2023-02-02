using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp5.Migrations
{
    public partial class AddRelationofSPCTvaGiohang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gioHangs_sanPhamChiTiets_sanPhamChiTietId",
                table: "gioHangs");

            migrationBuilder.DropIndex(
                name: "IX_gioHangs_sanPhamChiTietId",
                table: "gioHangs");

            migrationBuilder.DropColumn(
                name: "sanPhamChiTietId",
                table: "gioHangs");

            migrationBuilder.CreateIndex(
                name: "IX_gioHangs_Id_spct",
                table: "gioHangs",
                column: "Id_spct");

            migrationBuilder.AddForeignKey(
                name: "FK_gioHangs_sanPhamChiTiets_Id_spct",
                table: "gioHangs",
                column: "Id_spct",
                principalTable: "sanPhamChiTiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gioHangs_sanPhamChiTiets_Id_spct",
                table: "gioHangs");

            migrationBuilder.DropIndex(
                name: "IX_gioHangs_Id_spct",
                table: "gioHangs");

            migrationBuilder.AddColumn<int>(
                name: "sanPhamChiTietId",
                table: "gioHangs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_gioHangs_sanPhamChiTietId",
                table: "gioHangs",
                column: "sanPhamChiTietId");

            migrationBuilder.AddForeignKey(
                name: "FK_gioHangs_sanPhamChiTiets_sanPhamChiTietId",
                table: "gioHangs",
                column: "sanPhamChiTietId",
                principalTable: "sanPhamChiTiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
