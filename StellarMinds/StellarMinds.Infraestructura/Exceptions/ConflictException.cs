
namespace StellarMinds.Infraestructura.EF.Exceptions
{
    public class ConflictException : InfraestructuraExcepcion
    {
        public ConflictException()
        {
        }
        public ConflictException(string mensaje) : base(mensaje)
        {
        }
        public override int StatusCode()
        {
            return 409;
        }
    }
}
