namespace StellarMinds.LogicaNegocio.Excepciones.VOExceptions
{
    public class LogicaNegocioExcepcion : Exception

    {
        public LogicaNegocioExcepcion()
        {
        }

        public LogicaNegocioExcepcion(string? message)
        {
        }

        public LogicaNegocioExcepcion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
