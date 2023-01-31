using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp5.Migrations
{
    public partial class AddTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_phanquyen",
                table: "NguoiDungs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DiaChi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Nguoidung = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaChi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaChi_NguoiDungs_Id_Nguoidung",
                        column: x => x.Id_Nguoidung,
                        principalTable: "NguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhanQuyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyen", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungs_Id_phanquyen",
                table: "NguoiDungs",
                column: "Id_phanquyen");

            migrationBuilder.CreateIndex(
                name: "IX_DiaChi_Id_Nguoidung",
                table: "DiaChi",
                column: "Id_Nguoidung");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDungs_PhanQuyen_Id_phanquyen",
                table: "NguoiDungs",
                column: "Id_phanquyen",
                principalTable: "PhanQuyen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDungs_PhanQuyen_Id_phanquyen",
                table: "NguoiDungs");

            migrationBuilder.DropTable(
                name: "DiaChi");

            migrationBuilder.DropTable(
                name: "PhanQuyen");

            migrationBuilder.DropIndex(
                name: "IX_NguoiDungs_Id_phanquyen",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "Id_phanquyen",
                table: "NguoiDungs");
        }
    }
}
