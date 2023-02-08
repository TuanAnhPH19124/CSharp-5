using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdateNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hoaDons_giamGiaHDs_Id_GiamGia",
                table: "hoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_sanPhamChiTiets_giamGiaSPs_Id_GiamGia",
                table: "sanPhamChiTiets");

            migrationBuilder.AlterColumn<int>(
                name: "Id_GiamGia",
                table: "sanPhamChiTiets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id_GiamGia",
                table: "hoaDons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_hoaDons_giamGiaHDs_Id_GiamGia",
                table: "hoaDons",
                column: "Id_GiamGia",
                principalTable: "giamGiaHDs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sanPhamChiTiets_giamGiaSPs_Id_GiamGia",
                table: "sanPhamChiTiets",
                column: "Id_GiamGia",
                principalTable: "giamGiaSPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hoaDons_giamGiaHDs_Id_GiamGia",
                table: "hoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_sanPhamChiTiets_giamGiaSPs_Id_GiamGia",
                table: "sanPhamChiTiets");

            migrationBuilder.AlterColumn<int>(
                name: "Id_GiamGia",
                table: "sanPhamChiTiets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_GiamGia",
                table: "hoaDons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
