using Microsoft.EntityFrameworkCore.Migrations;

namespace FabiApi.Migrations
{
    public partial class fieldlote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoteId",
                table: "DocumentoDetalles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoDetalles_LoteId",
                table: "DocumentoDetalles",
                column: "LoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentoDetalles_Lote_LoteId",
                table: "DocumentoDetalles",
                column: "LoteId",
                principalTable: "Lote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentoDetalles_Lote_LoteId",
                table: "DocumentoDetalles");

            migrationBuilder.DropIndex(
                name: "IX_DocumentoDetalles_LoteId",
                table: "DocumentoDetalles");

            migrationBuilder.DropColumn(
                name: "LoteId",
                table: "DocumentoDetalles");
        }
    }
}
