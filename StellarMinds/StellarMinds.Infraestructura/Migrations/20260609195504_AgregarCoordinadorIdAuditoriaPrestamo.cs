using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StellarMinds.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCoordinadorIdAuditoriaPrestamo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoordinadorId",
                table: "AuditoriasPrestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordinadorId",
                table: "AuditoriasPrestamos");
        }
    }
}
