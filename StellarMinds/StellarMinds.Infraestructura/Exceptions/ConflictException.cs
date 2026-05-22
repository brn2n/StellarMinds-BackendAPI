
namespace Libreria.Infraestuctura.AccesoDatos.Excepciones
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
