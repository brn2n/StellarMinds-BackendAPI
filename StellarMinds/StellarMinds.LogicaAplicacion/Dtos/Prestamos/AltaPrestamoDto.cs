namespace StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos
{
    public record AltaPrestamoDto(
        DateTime FechaFin,
        int SocioId,
        int? TelescopioId,
        int? MonturaId,
        int? CamaraId,
        int? OcularId
    );
}

