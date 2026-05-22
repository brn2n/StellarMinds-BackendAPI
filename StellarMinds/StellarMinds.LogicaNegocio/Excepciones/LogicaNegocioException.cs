using StellarMinds.LogicaNegocio.Excepciones.Error;

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

        public ErrorCodigo Error()
        {
            return new ErrorCodigo(
                400,
                this.Message ?? string.Empty
            );
        }
    }
}
