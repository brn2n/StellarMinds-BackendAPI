
namespace StellarMinds.Infraestructura.EF.Exceptions

{
    public class BadRequestException : InfraestructuraExcepcion
    {
        public BadRequestException()
        {
        }
        public BadRequestException(string mensaje) : base(mensaje)
        {
        }
        public override int StatusCode()
        {
            return 400;
        }
    }
}