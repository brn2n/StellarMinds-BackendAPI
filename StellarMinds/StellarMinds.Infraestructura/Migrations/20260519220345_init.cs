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
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
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
                    Magnitud = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetosCelestes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "ObjetosCelestes");
        }
    }
}
