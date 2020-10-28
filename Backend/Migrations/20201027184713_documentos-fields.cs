using Microsoft.EntityFrameworkCore.Migrations;

namespace FabiApi.Migrations
{
    public partial class documentosfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Documento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Proveedor",
                table: "Documento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Documento");

            migrationBuilder.DropColumn(
                name: "Proveedor",
                table: "Documento");
        }
    }
}
