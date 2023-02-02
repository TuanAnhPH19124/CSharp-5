using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp5.Migrations
{
    public partial class AddRelationofSPCT_hinhanh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hinhAnhSPs_sanPhamChiTiets_sanPhamChiTietId",
                table: "hinhAnhSPs");

            migrationBuilder.DropIndex(
                name: "IX_hinhAnhSPs_sanPhamChiTietId",
                table: "hinhAnhSPs");

            migrationBuilder.DropColumn(
                name: "sanPhamChiTietId",
                table: "hinhAnhSPs");

            migrationBuilder.CreateIndex(
                name: "IX_hinhAnhSPs_Id_SPCT",
                table: "hinhAnhSPs",
                column: "Id_SPCT");

            migrationBuilder.AddForeignKey(
                name: "FK_hinhAnhSPs_sanPhamChiTiets_Id_SPCT",
                table: "hinhAnhSPs",
                column: "Id_SPCT",
                principalTable: "sanPhamChiTiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hinhAnhSPs_sanPhamChiTiets_Id_SPCT",
                table: "hinhAnhSPs");

            migrationBuilder.DropIndex(
                name: "IX_hinhAnhSPs_Id_SPCT",
                table: "hinhAnhSPs");

            migrationBuilder.AddColumn<int>(
                name: "sanPhamChiTietId",
                table: "hinhAnhSPs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_hinhAnhSPs_sanPhamChiTietId",
                table: "hinhAnhSPs",
                column: "sanPhamChiTietId");

            migrationBuilder.AddForeignKey(
                name: "FK_hinhAnhSPs_sanPhamChiTiets_sanPhamChiTietId",
                table: "hinhAnhSPs",
                column: "sanPhamChiTietId",
                principalTable: "sanPhamChiTiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
