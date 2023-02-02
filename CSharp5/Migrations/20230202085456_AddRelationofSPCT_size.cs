using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp5.Migrations
{
    public partial class AddRelationofSPCT_size : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sizes_sanPhamChiTiets_sanPhamChiTietId",
                table: "sizes");

            migrationBuilder.DropIndex(
                name: "IX_sizes_sanPhamChiTietId",
                table: "sizes");

            migrationBuilder.DropColumn(
                name: "sanPhamChiTietId",
                table: "sizes");

            migrationBuilder.CreateIndex(
                name: "IX_sizes_Id_SPCT",
                table: "sizes",
                column: "Id_SPCT");

            migrationBuilder.AddForeignKey(
                name: "FK_sizes_sanPhamChiTiets_Id_SPCT",
                table: "sizes",
                column: "Id_SPCT",
                principalTable: "sanPhamChiTiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sizes_sanPhamChiTiets_Id_SPCT",
                table: "sizes");

            migrationBuilder.DropIndex(
                name: "IX_sizes_Id_SPCT",
                table: "sizes");

            migrationBuilder.AddColumn<int>(
                name: "sanPhamChiTietId",
                table: "sizes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_sizes_sanPhamChiTietId",
                table: "sizes",
                column: "sanPhamChiTietId");

            migrationBuilder.AddForeignKey(
                name: "FK_sizes_sanPhamChiTiets_sanPhamChiTietId",
                table: "sizes",
                column: "sanPhamChiTietId",
                principalTable: "sanPhamChiTiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
