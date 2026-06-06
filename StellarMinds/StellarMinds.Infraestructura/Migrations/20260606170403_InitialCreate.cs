using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StellarMinds.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SocioId",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_SocioId",
                table: "Prestamos",
                column: "SocioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Usuarios_SocioId",
                table: "Prestamos",
                column: "SocioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Usuarios_SocioId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_SocioId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "SocioId",
                table: "Prestamos");
        }
    }
}
