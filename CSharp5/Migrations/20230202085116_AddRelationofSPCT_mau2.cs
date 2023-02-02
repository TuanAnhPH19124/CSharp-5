using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp5.Migrations
{
    public partial class AddRelationofSPCT_mau2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sPCT_Maus_sanPhamChiTiets_sanPhamChiTietId",
                table: "sPCT_Maus");

            migrationBuilder.DropIndex(
                name: "IX_sPCT_Maus_sanPhamChiTietId",
                table: "sPCT_Maus");

            migrationBuilder.DropColumn(
                name: "sanPhamChiTietId",
                table: "sPCT_Maus");

            migrationBuilder.CreateIndex(
                name: "IX_sPCT_Maus_Id_spct",
                table: "sPCT_Maus",
                column: "Id_spct");

            migrationBuilder.AddForeignKey(
                name: "FK_sPCT_Maus_sanPhamChiTiets_Id_spct",
                table: "sPCT_Maus",
                column: "Id_spct",
                principalTable: "sanPhamChiTiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sPCT_Maus_sanPhamChiTiets_Id_spct",
                table: "sPCT_Maus");

            migrationBuilder.DropIndex(
                name: "IX_sPCT_Maus_Id_spct",
                table: "sPCT_Maus");

            migrationBuilder.AddColumn<int>(
                name: "sanPhamChiTietId",
                table: "sPCT_Maus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_sPCT_Maus_sanPhamChiTietId",
                table: "sPCT_Maus",
                column: "sanPhamChiTietId");

            migrationBuilder.AddForeignKey(
                name: "FK_sPCT_Maus_sanPhamChiTiets_sanPhamChiTietId",
                table: "sPCT_Maus",
                column: "sanPhamChiTietId",
                principalTable: "sanPhamChiTiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
