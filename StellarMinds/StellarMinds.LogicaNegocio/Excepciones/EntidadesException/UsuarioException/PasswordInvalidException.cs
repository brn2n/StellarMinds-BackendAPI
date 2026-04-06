using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones.EntidadesException.UsuarioException
{
    public class PasswordInvalidException : LogicaNegocioExcepcion
    {
        public PasswordInvalidException()
        {
        }

        public PasswordInvalidException(string? message) : base(message)
        {
        }
    }
}
