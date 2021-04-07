using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trabajo_Final_Desarro_Web.Migrations
{
    public partial class DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Condicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nro_DNI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Inscripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tema_Interes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "alquilers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Fecha_Alquiler = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor_Alquiler = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alquilers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_alquilers_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalle_Alquilers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdId = table.Column<int>(type: "int", nullable: false),
                    AlquilerId = table.Column<int>(type: "int", nullable: false),
                    Dias_Prestamo = table.Column<int>(type: "int", nullable: false),
                    Fecha_Devolucion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_Alquilers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalle_Alquilers_alquilers_AlquilerId",
                        column: x => x.AlquilerId,
                        principalTable: "alquilers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_Alquilers_CDs_CdId",
                        column: x => x.CdId,
                        principalTable: "CDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sancions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlquilerId = table.Column<int>(type: "int", nullable: false),
                    Tipo_Sancion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nro_Dias_Sancion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sancions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sancions_alquilers_AlquilerId",
                        column: x => x.AlquilerId,
                        principalTable: "alquilers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alquilers_ClienteId",
                table: "alquilers",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_Alquilers_AlquilerId",
                table: "detalle_Alquilers",
                column: "AlquilerId");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_Alquilers_CdId",
                table: "detalle_Alquilers",
                column: "CdId");

            migrationBuilder.CreateIndex(
                name: "IX_sancions_AlquilerId",
                table: "sancions",
                column: "AlquilerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_Alquilers");

            migrationBuilder.DropTable(
                name: "sancions");

            migrationBuilder.DropTable(
                name: "CDs");

            migrationBuilder.DropTable(
                name: "alquilers");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
