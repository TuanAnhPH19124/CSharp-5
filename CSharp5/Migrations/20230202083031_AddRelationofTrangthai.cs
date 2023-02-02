using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp5.Migrations
{
    public partial class AddRelationofTrangthai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quanLis_phanQuyens_phanQuyenId",
                table: "quanLis");

            migrationBuilder.DropForeignKey(
                name: "FK_trangThais_quanLis_quanLiId",
                table: "trangThais");

            migrationBuilder.DropIndex(
                name: "IX_trangThais_quanLiId",
                table: "trangThais");

            migrationBuilder.DropIndex(
                name: "IX_quanLis_phanQuyenId",
                table: "quanLis");

            migrationBuilder.DropColumn(
                name: "quanLiId",
                table: "trangThais");

            migrationBuilder.DropColumn(
                name: "phanQuyenId",
                table: "quanLis");

            migrationBuilder.CreateIndex(
                name: "IX_trangThais_Id_quanli",
                table: "trangThais",
                column: "Id_quanli");

            migrationBuilder.CreateIndex(
                name: "IX_quanLis_Id_phanquyen",
                table: "quanLis",
                column: "Id_phanquyen");

            migrationBuilder.AddForeignKey(
                name: "FK_quanLis_phanQuyens_Id_phanquyen",
                table: "quanLis",
                column: "Id_phanquyen",
                principalTable: "phanQuyens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trangThais_quanLis_Id_quanli",
                table: "trangThais",
                column: "Id_quanli",
                principalTable: "quanLis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quanLis_phanQuyens_Id_phanquyen",
                table: "quanLis");

            migrationBuilder.DropForeignKey(
                name: "FK_trangThais_quanLis_Id_quanli",
                table: "trangThais");

            migrationBuilder.DropIndex(
                name: "IX_trangThais_Id_quanli",
                table: "trangThais");

            migrationBuilder.DropIndex(
                name: "IX_quanLis_Id_phanquyen",
                table: "quanLis");

            migrationBuilder.AddColumn<int>(
                name: "quanLiId",
                table: "trangThais",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "phanQuyenId",
                table: "quanLis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_trangThais_quanLiId",
                table: "trangThais",
                column: "quanLiId");

            migrationBuilder.CreateIndex(
                name: "IX_quanLis_phanQuyenId",
                table: "quanLis",
                column: "phanQuyenId");

            migrationBuilder.AddForeignKey(
                name: "FK_quanLis_phanQuyens_phanQuyenId",
                table: "quanLis",
                column: "phanQuyenId",
                principalTable: "phanQuyens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trangThais_quanLis_quanLiId",
                table: "trangThais",
                column: "quanLiId",
                principalTable: "quanLis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
