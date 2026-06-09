using StellarMinds.Infraestructura.EF.Exceptions;

namespace StellarMinds.LogicaAplicacion.CUExceptions.CUEquipo
{
    public class equipoNoOcularException : BadRequestException
    {
        public equipoNoOcularException()
            : base("El equipo no es Ocular")
        {
        }

        public equipoNoOcularException(string mensaje)
            : base(mensaje)
        {
        }
    }
}