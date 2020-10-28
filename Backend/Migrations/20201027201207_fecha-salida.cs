using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FabiApi.Migrations
{
    public partial class fechasalida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSalida",
                table: "ProductoAuxiliar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaSalida",
                table: "ProductoAuxiliar");
        }
    }
}
