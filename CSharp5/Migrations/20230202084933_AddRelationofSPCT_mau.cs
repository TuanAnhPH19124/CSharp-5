using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp5.Migrations
{
    public partial class AddRelationofSPCT_mau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sanPhamChiTiets_sanPhams_sanPhamId",
                table: "sanPhamChiTiets");

            migrationBuilder.DropIndex(
                name: "IX_sanPhamChiTiets_sanPhamId",
                table: "sanPhamChiTiets");

            migrationBuilder.DropColumn(
                name: "sanPhamId",
                table: "sanPhamChiTiets");

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
                name: "sPCT_Maus",
                columns: table => new
                {
                    Id_mau = table.Column<int>(type: "int", nullable: false),
                    Id_spct = table.Column<int>(type: "int", nullable: false),
                    sanPhamChiTietId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_sPCT_Maus_sanPhamChiTiets_sanPhamChiTietId",
                        column: x => x.sanPhamChiTietId,
                        principalTable: "sanPhamChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sanPhamChiTiets_Id_SP",
                table: "sanPhamChiTiets",
                column: "Id_SP");

            migrationBuilder.CreateIndex(
                name: "IX_sPCT_Maus_sanPhamChiTietId",
                table: "sPCT_Maus",
                column: "sanPhamChiTietId");

            migrationBuilder.AddForeignKey(
                name: "FK_sanPhamChiTiets_sanPhams_Id_SP",
                table: "sanPhamChiTiets",
                column: "Id_SP",
                principalTable: "sanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sanPhamChiTiets_sanPhams_Id_SP",
                table: "sanPhamChiTiets");

            migrationBuilder.DropTable(
                name: "sPCT_Maus");

            migrationBuilder.DropTable(
                name: "maus");

            migrationBuilder.DropIndex(
                name: "IX_sanPhamChiTiets_Id_SP",
                table: "sanPhamChiTiets");

            migrationBuilder.AddColumn<int>(
                name: "sanPhamId",
                table: "sanPhamChiTiets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_sanPhamChiTiets_sanPhamId",
                table: "sanPhamChiTiets",
                column: "sanPhamId");

            migrationBuilder.AddForeignKey(
                name: "FK_sanPhamChiTiets_sanPhams_sanPhamId",
                table: "sanPhamChiTiets",
                column: "sanPhamId",
                principalTable: "sanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
