using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones.EntidadesException.UsuarioException
{
    public class UsuarioInvalidException : LogicaNegocioExcepcion
    {
        public UsuarioInvalidException()
        {
        }

        public UsuarioInvalidException(string? message) : base(message)
        {
        }
    }
}
