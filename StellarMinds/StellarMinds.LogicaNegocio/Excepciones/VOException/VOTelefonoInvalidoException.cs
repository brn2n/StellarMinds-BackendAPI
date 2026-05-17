namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class VOTelefonoInvalidoException : Exception
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
