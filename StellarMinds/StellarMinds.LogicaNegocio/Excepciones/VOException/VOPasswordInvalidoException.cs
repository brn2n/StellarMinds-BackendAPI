using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class VOPasswordInvalidoException : LogicaNegocioExcepcion
    {
        public VOPasswordInvalidoException()
            : base("La contraseña no es válida.")
        {
        }

        public VOPasswordInvalidoException(string mensaje)
            : base(mensaje)
        {
        }
    }
}