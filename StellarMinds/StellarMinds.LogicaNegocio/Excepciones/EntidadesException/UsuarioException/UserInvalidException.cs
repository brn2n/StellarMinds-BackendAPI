using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones.EntidadesException.UsuarioException
{
    public class UserInvalidException : LogicaNegocioExcepcion
    {
        public UserInvalidException() { }

        public UserInvalidException(string mensaje)
            : base(mensaje)
        {
        }

        public UserInvalidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
