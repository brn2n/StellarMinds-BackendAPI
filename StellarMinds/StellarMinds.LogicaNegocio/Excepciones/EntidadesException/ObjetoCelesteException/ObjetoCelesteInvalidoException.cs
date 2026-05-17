namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class ObjetoCelesteInvalidoException : Exception
    {
        public ObjetoCelesteInvalidoException()
            : base("El objeto celeste no es válido.")
        {
        }

        public ObjetoCelesteInvalidoException(string mensaje)
            : base(mensaje)
        {
        }
    }
}