using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones.EntidadesException.UsuarioException
{
    public class UsernameInvalidException : LogicaNegocioExcepcion
    {
        public UsernameInvalidException()
            : base("El username no es válido.")
        {
        }

        public UsernameInvalidException(string? message) : base(message)
        {
        }
    }
}
