namespace StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos
{
    public record PrestamoDto(
        int Id,
        DateTime FechaFin,
        int? TelescopioId,
        int? MonturaId,
        int? CamaraId,
        int? OcularId
    );
}
