using Microsoft.EntityFrameworkCore.Migrations;

namespace FabiApi.Migrations
{
    public partial class cantiadadrestante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadRestante",
                table: "ProductoAuxiliar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadRestante",
                table: "ProductoAuxiliar");
        }
    }
}
