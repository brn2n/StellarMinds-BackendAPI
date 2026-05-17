using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StellarMinds.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjetosCelestes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Magnitud = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetosCelestes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantDisponible = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: true),
                    TipoSensorCamara = table.Column<int>(type: "int", nullable: true),
                    Resolucion = table.Column<int>(type: "int", nullable: true),
                    TamanioPixel = table.Column<int>(type: "int", nullable: true),
                    TipoMontura = table.Column<int>(type: "int", nullable: true),
                    CargaUtilSoportada = table.Column<double>(type: "float", nullable: true),
                    Computarizada = table.Column<bool>(type: "bit", nullable: true),
                    Diametro = table.Column<double>(type: "float", nullable: true),
                    AnguloVision = table.Column<int>(type: "int", nullable: true),
                    Apertura = table.Column<double>(type: "float", nullable: true),
                    RelacionFocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistanciaFocal = table.Column<double>(type: "float", nullable: true),
                    Peso = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VOFechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OcularId = table.Column<int>(type: "int", nullable: false),
                    TelescopioId = table.Column<int>(type: "int", nullable: false),
                    CamaraId = table.Column<int>(type: "int", nullable: false),
                    MonturaId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamo_Equipo_CamaraId",
                        column: x => x.CamaraId,
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamo_Equipo_MonturaId",
                        column: x => x.MonturaId,
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamo_Equipo_OcularId",
                        column: x => x.OcularId,
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamo_Equipo_TelescopioId",
                        column: x => x.TelescopioId,
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NochesObservaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaObservacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    ObjetoCelesteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NochesObservaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NochesObservaciones_ObjetosCelestes_ObjetoCelesteId",
                        column: x => x.ObjetoCelesteId,
                        principalTable: "ObjetosCelestes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NochesObservaciones_Prestamo_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_PrestamoId",
                table: "Equipo",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_NochesObservaciones_ObjetoCelesteId",
                table: "NochesObservaciones",
                column: "ObjetoCelesteId");

            migrationBuilder.CreateIndex(
                name: "IX_NochesObservaciones_PrestamoId",
                table: "NochesObservaciones",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_CamaraId",
                table: "Prestamo",
                column: "CamaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_MonturaId",
                table: "Prestamo",
                column: "MonturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_OcularId",
                table: "Prestamo",
                column: "OcularId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_TelescopioId",
                table: "Prestamo",
                column: "TelescopioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_Prestamo_PrestamoId",
                table: "Equipo",
                column: "PrestamoId",
                principalTable: "Prestamo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_Prestamo_PrestamoId",
                table: "Equipo");

            migrationBuilder.DropTable(
                name: "NochesObservaciones");

            migrationBuilder.DropTable(
                name: "ObjetosCelestes");

            migrationBuilder.DropTable(
                name: "Prestamo");

            migrationBuilder.DropTable(
                name: "Equipo");
        }
    }
}
