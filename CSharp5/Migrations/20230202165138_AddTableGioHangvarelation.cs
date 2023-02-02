using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp5.Migrations
{
    public partial class AddTableGioHangvarelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gioHangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Id_spct = table.Column<int>(type: "int", nullable: false),
                    sanPhamChiTietId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_gioHangs_sanPhamChiTiets_sanPhamChiTietId",
                        column: x => x.sanPhamChiTietId,
                        principalTable: "sanPhamChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gioHangs_Id_nguoidung",
                table: "gioHangs",
                column: "Id_nguoidung");

            migrationBuilder.CreateIndex(
                name: "IX_gioHangs_sanPhamChiTietId",
                table: "gioHangs",
                column: "sanPhamChiTietId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gioHangs");
        }
    }
}
