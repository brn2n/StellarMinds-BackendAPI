namespace StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos
{
    public class ListadoPrestamoSocioDto
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public bool EstaAtrasado { get; set; }
    }
}