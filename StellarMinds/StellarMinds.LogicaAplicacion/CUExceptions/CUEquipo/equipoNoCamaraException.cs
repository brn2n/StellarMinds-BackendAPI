using StellarMinds.Infraestructura.EF.Exceptions;

namespace StellarMinds.LogicaAplicacion.CUExceptions.CUEquipo
{
    public class equipoNoCamaraException : BadRequestException
    {
        public equipoNoCamaraException()
            : base("El equipo no es Telescopio")
        {
        }

        public equipoNoCamaraException(string mensaje)
            : base(mensaje)
        {
        }
    }
}