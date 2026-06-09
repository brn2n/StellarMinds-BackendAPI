using StellarMinds.Infraestructura.EF.Exceptions;

namespace StellarMinds.LogicaAplicacion.CUExceptions.CUEquipo
{
    public class equipoNoMonturaException : BadRequestException
    {
        public equipoNoMonturaException()
            : base("El equipo no es Telescopio")
        {
        }

        public equipoNoMonturaException(string mensaje)
            : base(mensaje)
        {
        }
    }
}