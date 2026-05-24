namespace StellarMinds.LogicaNegocio.Excepciones.EntidadesException.EquipoException
{
    public class EquipoInvalidException : Exception
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
