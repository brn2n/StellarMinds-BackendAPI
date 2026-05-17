namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class VOUsernameInvalidoException : Exception
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