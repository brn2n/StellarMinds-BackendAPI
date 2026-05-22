namespace StellarMinds.WebApp.Models.NochesObservaciones
{
    public record AltaObservacionDto
    {
        public int IdPrestamo { get; set; }
        public int IdObjetoCeleste { get; set; }
        public DateTime FechaObservacion { get; set; }
    }
}
