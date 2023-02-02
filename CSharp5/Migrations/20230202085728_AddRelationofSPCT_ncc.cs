using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp5.Migrations
{
    public partial class AddRelationofSPCT_ncc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_nhaCungCaps_sanPhamChiTiets_sanPhamChiTietId",
                table: "nhaCungCaps");

            migrationBuilder.DropIndex(
                name: "IX_nhaCungCaps_sanPhamChiTietId",
                table: "nhaCungCaps");

            migrationBuilder.DropColumn(
                name: "sanPhamChiTietId",
                table: "nhaCungCaps");

            migrationBuilder.CreateIndex(
                name: "IX_nhaCungCaps_Id_SPCT",
                table: "nhaCungCaps",
                column: "Id_SPCT");

            migrationBuilder.AddForeignKey(
                name: "FK_nhaCungCaps_sanPhamChiTiets_Id_SPCT",
                table: "nhaCungCaps",
                column: "Id_SPCT",
                principalTable: "sanPhamChiTiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_nhaCungCaps_sanPhamChiTiets_Id_SPCT",
                table: "nhaCungCaps");

            migrationBuilder.DropIndex(
                name: "IX_nhaCungCaps_Id_SPCT",
                table: "nhaCungCaps");

            migrationBuilder.AddColumn<int>(
                name: "sanPhamChiTietId",
                table: "nhaCungCaps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_nhaCungCaps_sanPhamChiTietId",
                table: "nhaCungCaps",
                column: "sanPhamChiTietId");

            migrationBuilder.AddForeignKey(
                name: "FK_nhaCungCaps_sanPhamChiTiets_sanPhamChiTietId",
                table: "nhaCungCaps",
                column: "sanPhamChiTietId",
                principalTable: "sanPhamChiTiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
