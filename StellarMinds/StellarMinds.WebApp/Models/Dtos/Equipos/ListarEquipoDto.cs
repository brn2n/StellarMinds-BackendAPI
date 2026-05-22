

namespace StellarMinds.WebApp.Models.Dtos.Equipos
{
    public record ListarEquipoDto(
        int Id,
        string TipoEquipo,
        string Marca,
        string Modelo,
        int CantDisponible,

        // Telescopio
        double? Apertura,
        string? RelacionFocal,
        double? DistanciaFocal,
        double? Peso,

        // Montura
        int TipoMontura,
        double? CargaUtilSoportada,
        bool? Computarizada,

        // Cámara
        int TipoSensorCamara,
        int? Resolucion,
        int? TamanioPixel,

        // Ocular
        double? Diametro,
        int? AnguloVision)
    {
    }
}
