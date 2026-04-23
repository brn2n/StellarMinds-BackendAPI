
namespace StellarMinds.LogicaAplicacion.Dtos.Equipos
{
    namespace StellarMinds.LogicaAplicacion.Dtos.Equipos
    {
        public record AltaEquipoDto
        {
           public int Id { get; init; }
            public string TipoEquipo { get; set; }
            public string Marca { get; set; } 
            public string Modelo { get; set; } 
            public int CantDisponible { get; set; }
            public double? Apertura { get; set; }
            public string? RelacionFocal { get; set; }
            public double? DistanciaFocal { get; set; }
            public double? Peso { get; set; }
            public string? TipoMontura { get; set; }
            public double? CargaUtilSoportada { get; set; }
            public string? TipoSensor { get; set; }
            public double? ResolucionMP { get; set; }
            public bool? EsColor { get; set; }
            public double? DistanciaFocalOcular { get; set; }
            public double? CampoVision { get; set; }
        }
    }
}
