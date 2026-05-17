namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class VOPasswordInvalidoException : Exception
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