namespace StellarMinds.Infraestructura.EF.Exceptions
{
    public class NotFoundException : InfraestructuraExcepcion
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string mensaje) : base(mensaje)
        {
        }

        public override int StatusCode()
        {
            return 404;
        }
    }
}
