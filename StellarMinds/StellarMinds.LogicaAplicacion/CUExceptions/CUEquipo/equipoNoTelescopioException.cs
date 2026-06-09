using StellarMinds.Infraestructura.EF.Exceptions;

namespace StellarMinds.LogicaAplicacion.CUExceptions.CUEquipo
{
    public class equipoNoTelescopioException : BadRequestException
    {
        public equipoNoTelescopioException()
            : base("El equipo no es Telescopio")
        {
        }

        public equipoNoTelescopioException(string mensaje)
            : base(mensaje)
        {
        }
    }
}