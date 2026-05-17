namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class VONombreObjetoCelesteInvalidoException : Exception
    {
        public VONombreObjetoCelesteInvalidoException()
            : base("El nombre del objeto celeste no es válido.")
        {
        }

        public VONombreObjetoCelesteInvalidoException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
