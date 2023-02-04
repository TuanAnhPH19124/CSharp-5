using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp5.Migrations
{
    public partial class AddTableGiamGiaSPvaRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hoaDons_GiamGiaHD_Id_GiamGia",
                table: "hoaDons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GiamGiaHD",
                table: "GiamGiaHD");

            migrationBuilder.RenameTable(
                name: "GiamGiaHD",
                newName: "giamGiaHDs");

            migrationBuilder.AddColumn<int>(
                name: "Id_GiamGia",
                table: "sanPhamChiTiets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_giamGiaHDs",
                table: "giamGiaHDs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "giamGiaSPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiaTri = table.Column<double>(type: "float", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_giamGiaSPs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sanPhamChiTiets_Id_GiamGia",
                table: "sanPhamChiTiets",
                column: "Id_GiamGia");

            migrationBuilder.AddForeignKey(
                name: "FK_hoaDons_giamGiaHDs_Id_GiamGia",
                table: "hoaDons",
                column: "Id_GiamGia",
                principalTable: "giamGiaHDs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sanPhamChiTiets_giamGiaSPs_Id_GiamGia",
                table: "sanPhamChiTiets",
                column: "Id_GiamGia",
                principalTable: "giamGiaSPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hoaDons_giamGiaHDs_Id_GiamGia",
                table: "hoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_sanPhamChiTiets_giamGiaSPs_Id_GiamGia",
                table: "sanPhamChiTiets");

            migrationBuilder.DropTable(
                name: "giamGiaSPs");

            migrationBuilder.DropIndex(
                name: "IX_sanPhamChiTiets_Id_GiamGia",
                table: "sanPhamChiTiets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_giamGiaHDs",
                table: "giamGiaHDs");

            migrationBuilder.DropColumn(
                name: "Id_GiamGia",
                table: "sanPhamChiTiets");

            migrationBuilder.RenameTable(
                name: "giamGiaHDs",
                newName: "GiamGiaHD");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiamGiaHD",
                table: "GiamGiaHD",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_hoaDons_GiamGiaHD_Id_GiamGia",
                table: "hoaDons",
                column: "Id_GiamGia",
                principalTable: "GiamGiaHD",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
