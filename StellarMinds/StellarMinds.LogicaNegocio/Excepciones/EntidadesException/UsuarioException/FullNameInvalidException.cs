using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones.EntidadesException.UsuarioException
{
    public class FullNameInvalidException : LogicaNegocioExcepcion
    {
        public FullNameInvalidException() { }


        public FullNameInvalidException(string mensaje)
            : base(mensaje)
        {
        }

        public FullNameInvalidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}

