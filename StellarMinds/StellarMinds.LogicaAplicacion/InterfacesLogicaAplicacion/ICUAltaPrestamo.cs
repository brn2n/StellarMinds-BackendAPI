using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;

namespace StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion
{
    public interface ICUAltaPrestamo
    {
        void Ejecutar(AltaPrestamoDto dto, int coordinadorId);
    }
}