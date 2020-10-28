using Microsoft.EntityFrameworkCore.Migrations;

namespace FabiApi.Migrations
{
    public partial class fieldcdomento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentoId",
                table: "DocumentoDetalles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoDetalles_DocumentoId",
                table: "DocumentoDetalles",
                column: "DocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentoDetalles_Documento_DocumentoId",
                table: "DocumentoDetalles",
                column: "DocumentoId",
                principalTable: "Documento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentoDetalles_Documento_DocumentoId",
                table: "DocumentoDetalles");

            migrationBuilder.DropIndex(
                name: "IX_DocumentoDetalles_DocumentoId",
                table: "DocumentoDetalles");

            migrationBuilder.DropColumn(
                name: "DocumentoId",
                table: "DocumentoDetalles");
        }
    }
}
