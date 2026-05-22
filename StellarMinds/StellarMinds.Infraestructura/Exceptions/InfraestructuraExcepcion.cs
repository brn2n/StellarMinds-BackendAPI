using StellarMinds.LogicaNegocio.Excepciones.Error;

namespace Libreria.Infraestuctura.AccesoDatos.Excepciones
{
    public abstract class InfraestructuraExcepcion : Exception
    {
        private string _message;

        public InfraestructuraExcepcion()
        {
        }

        public InfraestructuraExcepcion(string mensaje) : base(mensaje)
        {
            _message = mensaje;
        }

        public abstract int StatusCode();

        public ErrorCodigo Error()
        {
            return new ErrorCodigo(
                StatusCode(),
                _message
                );
        }
    }
}
