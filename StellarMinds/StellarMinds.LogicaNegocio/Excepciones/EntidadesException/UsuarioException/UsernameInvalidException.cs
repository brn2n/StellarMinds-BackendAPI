using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones.EntidadesException.UsuarioException
{
    public class UsernameInvalidException : LogicaNegocioExcepcion
    {
        public UsernameInvalidException()
        {
        }

        public UsernameInvalidException(string? message) : base(message)
        {
        }
    }
}
