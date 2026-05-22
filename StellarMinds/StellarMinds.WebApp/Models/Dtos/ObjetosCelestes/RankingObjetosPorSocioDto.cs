namespace StellarMinds.WebApp.Models.Dtos.ObjetosCelestes
{
    public record RankingObjetosPorSocioDto
    {
        public string NombreObjeto { get; set; }
        public string Tipo { get; set; }
        public int CantidadObservaciones { get; set; }
    }
}
