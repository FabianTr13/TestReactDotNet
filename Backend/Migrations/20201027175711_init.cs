using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FabiApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaCreado = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Abierto = table.Column<bool>(nullable: false),
                    FechaCreado = table.Column<DateTime>(nullable: false),
                    FechaCerrado = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaCreado = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTransaccions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTransaccions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoteDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    CantidadUsada = table.Column<int>(nullable: false),
                    FechaCreado = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoteDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoteDetalles_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentoDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoTransaccionId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Costo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentoDetalles_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentoDetalles_TipoTransaccions_TipoTransaccionId",
                        column: x => x.TipoTransaccionId,
                        principalTable: "TipoTransaccions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoAuxiliar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    tipoTransaccionId = table.Column<int>(nullable: false),
                    DocumentoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    LoteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoAuxiliar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoAuxiliar_Documento_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "Documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoAuxiliar_Lote_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoAuxiliar_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoAuxiliar_TipoTransaccions_tipoTransaccionId",
                        column: x => x.tipoTransaccionId,
                        principalTable: "TipoTransaccions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoDetalles_ProductoId",
                table: "DocumentoDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoDetalles_TipoTransaccionId",
                table: "DocumentoDetalles",
                column: "TipoTransaccionId");

            migrationBuilder.CreateIndex(
                name: "IX_LoteDetalles_ProductoId",
                table: "LoteDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoAuxiliar_DocumentoId",
                table: "ProductoAuxiliar",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoAuxiliar_LoteId",
                table: "ProductoAuxiliar",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoAuxiliar_ProductoId",
                table: "ProductoAuxiliar",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoAuxiliar_tipoTransaccionId",
                table: "ProductoAuxiliar",
                column: "tipoTransaccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentoDetalles");

            migrationBuilder.DropTable(
                name: "LoteDetalles");

            migrationBuilder.DropTable(
                name: "ProductoAuxiliar");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "TipoTransaccions");
        }
    }
}
