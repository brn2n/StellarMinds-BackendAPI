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
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantDisponible = table.Column<int>(type: "int", nullable: false),
                    TipoEquipo = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    TipoSensorCamara = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resolucion = table.Column<int>(type: "int", nullable: true),
                    TamanioPixel = table.Column<int>(type: "int", nullable: true),
                    TipoMontura = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjetosCelestes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Magnitud = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetosCelestes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCompleto_Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono_Value = table.Column<int>(type: "int", nullable: false),
                    Username_Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VOPassword_Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUsuario = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OcularId = table.Column<int>(type: "int", nullable: false),
                    TelescopioId = table.Column<int>(type: "int", nullable: false),
                    CamaraId = table.Column<int>(type: "int", nullable: false),
                    MonturaId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamos_Equipos_CamaraId",
                        column: x => x.CamaraId,
                        principalTable: "Equipos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prestamos_Equipos_MonturaId",
                        column: x => x.MonturaId,
                        principalTable: "Equipos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prestamos_Equipos_OcularId",
                        column: x => x.OcularId,
                        principalTable: "Equipos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prestamos_Equipos_TelescopioId",
                        column: x => x.TelescopioId,
                        principalTable: "Equipos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuditoriasPrestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditoriasPrestamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditoriasPrestamos_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NochesObservaciones_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriasPrestamos_PrestamoId",
                table: "AuditoriasPrestamos",
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
                name: "IX_Prestamos_CamaraId",
                table: "Prestamos",
                column: "CamaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_MonturaId",
                table: "Prestamos",
                column: "MonturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_OcularId",
                table: "Prestamos",
                column: "OcularId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_TelescopioId",
                table: "Prestamos",
                column: "TelescopioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditoriasPrestamos");

            migrationBuilder.DropTable(
                name: "NochesObservaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "ObjetosCelestes");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Equipos");
        }
    }
}
