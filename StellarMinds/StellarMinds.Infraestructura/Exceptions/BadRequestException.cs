
namespace Libreria.Infraestuctura.AccesoDatos.Excepciones
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