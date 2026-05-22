namespace StellarMinds.WebApp.Models.Dtos.Prestamos
{
    public record InfoAuditoriaPrestamosDto
    {
        public int IdPrestamo { get; set; }
        public string UsuarioCoordinador { get; set; }
        public DateTime Fecha { get; set; }
    }
}
