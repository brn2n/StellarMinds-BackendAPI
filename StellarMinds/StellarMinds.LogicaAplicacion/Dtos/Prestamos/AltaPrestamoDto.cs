namespace StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos
{
    public record AltaPrestamoDto(
        int Id,
        DateTime FechaFin,
        int? TelescopioId,
        int? MonturaId,
        int? CamaraId,
        int? OcularId
    );
}
