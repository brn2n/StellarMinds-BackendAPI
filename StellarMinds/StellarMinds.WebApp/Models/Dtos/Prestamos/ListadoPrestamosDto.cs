namespace StellarMinds.WebApp.Models.Dtos.Prestamos
{
    public record ListadoPrestamosDto
    {
        public int IdPrestamo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public bool Atrasado { get; set; }
    }
}
