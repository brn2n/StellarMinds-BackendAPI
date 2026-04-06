using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones.EntidadesException.NocheObservacionException
{
    public class NocheObservacionInvalidException : LogicaNegocioExcepcion
    {
        public NocheObservacionInvalidException()
        {
        }

        public NocheObservacionInvalidException(string? message) : base(message)
        {
        }
    }
}
