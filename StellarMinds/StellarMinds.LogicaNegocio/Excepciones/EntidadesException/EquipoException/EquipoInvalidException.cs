using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.LogicaNegocio.Excepciones.EntidadesException.EquipoException
{
    public class EquipoInvalidException : LogicaNegocioExcepcion
    {
        public EquipoInvalidException()
            : base("El equipo no es válido.")
        {
        }

        public EquipoInvalidException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
