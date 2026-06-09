using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class VONombreCompletoInvalidoException : LogicaNegocioExcepcion
    {
        public VONombreCompletoInvalidoException()
            : base("El nombre completo ingresado no es válido.")
        {
        }

        public VONombreCompletoInvalidoException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
