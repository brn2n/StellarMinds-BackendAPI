using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones.EntidadesException.ObjetoCelesteException
{
    public class ObjetoCelesteInvalidException : LogicaNegocioExcepcion
    {
        public ObjetoCelesteInvalidException()
        {
        }

        public ObjetoCelesteInvalidException(string? message) : base(message)
        {
        }
    }
}
