
using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.LogicaAplicacion.Dtos.Equipos
{
    public record AltaEquipoDto(
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
        TipoMontura? TipoMontura,
        double? CargaUtilSoportada,
        bool? Computarizada,

        // Cámara
        TipoSensorCamara? TipoSensorCamara,
        int? Resolucion,
        int? TamanioPixel,

        // Ocular
        double? Diametro,
        int? AnguloVision
    );
}

