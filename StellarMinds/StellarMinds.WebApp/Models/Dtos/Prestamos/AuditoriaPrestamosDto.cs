namespace StellarMinds.WebApp.Models.Dtos.Prestamos
{
    public record AuditoriaPrestamosDto
    {
        public int IdPrestamo { get; set; }
        public string Usuario { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
