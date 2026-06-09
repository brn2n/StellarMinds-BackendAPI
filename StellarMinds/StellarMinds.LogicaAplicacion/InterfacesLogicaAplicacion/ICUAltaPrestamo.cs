using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;

namespace StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion
{
    public interface ICUAltaPrestamo
    {
        int Ejecutar(AltaPrestamoDto dto, int coordinadorId);
    }
}