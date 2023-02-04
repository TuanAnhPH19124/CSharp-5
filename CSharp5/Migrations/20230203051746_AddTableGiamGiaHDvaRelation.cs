using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp5.Migrations
{
    public partial class AddTableGiamGiaHDvaRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_GiamGia",
                table: "hoaDons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GiamGiaHD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaTri = table.Column<double>(type: "float", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KhongGioiHan = table.Column<bool>(type: "bit", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamGiaHD", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_Id_GiamGia",
                table: "hoaDons",
                column: "Id_GiamGia");

            migrationBuilder.AddForeignKey(
                name: "FK_hoaDons_GiamGiaHD_Id_GiamGia",
                table: "hoaDons",
                column: "Id_GiamGia",
                principalTable: "GiamGiaHD",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hoaDons_GiamGiaHD_Id_GiamGia",
                table: "hoaDons");

            migrationBuilder.DropTable(
                name: "GiamGiaHD");

            migrationBuilder.DropIndex(
                name: "IX_hoaDons_Id_GiamGia",
                table: "hoaDons");

            migrationBuilder.DropColumn(
                name: "Id_GiamGia",
                table: "hoaDons");
        }
    }
}
