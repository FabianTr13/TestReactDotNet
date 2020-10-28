using Microsoft.EntityFrameworkCore.Migrations;

namespace FabiApi.Migrations
{
    public partial class lotesreference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoteId",
                table: "LoteDetalles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LoteDetalles_LoteId",
                table: "LoteDetalles",
                column: "LoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoteDetalles_Lote_LoteId",
                table: "LoteDetalles",
                column: "LoteId",
                principalTable: "Lote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoteDetalles_Lote_LoteId",
                table: "LoteDetalles");

            migrationBuilder.DropIndex(
                name: "IX_LoteDetalles_LoteId",
                table: "LoteDetalles");

            migrationBuilder.DropColumn(
                name: "LoteId",
                table: "LoteDetalles");
        }
    }
}
