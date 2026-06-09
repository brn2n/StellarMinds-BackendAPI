using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class VOUsernameInvalidoException : LogicaNegocioExcepcion
    {
        public VOUsernameInvalidoException()
            : base("El username no es válido.")
        {
        }

        public VOUsernameInvalidoException(string mensaje)
            : base(mensaje)
        {
        }
    }
}