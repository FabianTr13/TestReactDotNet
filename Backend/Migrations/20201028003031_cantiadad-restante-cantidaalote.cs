using Microsoft.EntityFrameworkCore.Migrations;

namespace FabiApi.Migrations
{
    public partial class cantiadadrestantecantidaalote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadRestante",
                table: "LoteDetalles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadRestante",
                table: "LoteDetalles");
        }
    }
}
