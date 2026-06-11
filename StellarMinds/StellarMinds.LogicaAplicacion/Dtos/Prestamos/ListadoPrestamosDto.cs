namespace StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos
{
    public record ListadoPrestamoSocioDto(int Id, int SocioId, DateTime FechaInicio, DateTime FechaFin, string Estado, bool EstaAtrasado)
    {
    }
}