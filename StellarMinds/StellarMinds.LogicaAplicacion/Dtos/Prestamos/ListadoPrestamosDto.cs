namespace StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos
{
    public record ListadoPrestamoSocioDto
    {
        public int Id { get; set; }
        public int SocioId { get; set; }

        public int TelescopioId { get; set; }
        public int? CamaraId { get; set; }
        public int? MonturaId { get; set; }
        public int? OcularId { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public string Estado { get; set; } = string.Empty;
        public bool EstaAtrasado { get; set; }
    }
}