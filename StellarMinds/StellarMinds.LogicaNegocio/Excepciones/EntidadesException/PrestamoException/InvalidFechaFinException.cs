using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones.EntidadesException.PrestamoException
{
    public class InvalidFechaFinException : LogicaNegocioExcepcion
    {
        public InvalidFechaFinException()
        {
        }

        public InvalidFechaFinException(string? message) : base(message)
        {
        }
    }
}
