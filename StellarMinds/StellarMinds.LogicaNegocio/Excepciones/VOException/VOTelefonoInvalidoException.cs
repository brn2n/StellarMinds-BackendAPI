using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class VOTelefonoInvalidoException : LogicaNegocioExcepcion
    {
        public VOTelefonoInvalidoException()
            : base("El teléfono no es válido.")
        {
        }

        public VOTelefonoInvalidoException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
