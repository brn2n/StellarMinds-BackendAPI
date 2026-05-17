namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class VONombreCompletoInvalidoException : Exception
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
