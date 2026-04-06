using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones.EntidadesException.UsuarioException
{
    public class NameInvalidException : LogicaNegocioExcepcion
    {
        public NameInvalidException() { }


        public NameInvalidException(string? message) : base(message)
        {
        }

        public NameInvalidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}

