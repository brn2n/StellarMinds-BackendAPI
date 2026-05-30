namespace StellarMinds.LogicaAplicacion.Dtos.ObservacionDtos
{
    public class AltaObservacionDto
    {
        public int SocioId { get; set; }
        public int PrestamoId { get; set; }
        public int ObjetoCelesteId { get; set; }
        public DateTime FechaObservacion { get; set; }
    }
}