
namespace StellarMinds.LogicaNegocio.Excepciones
{
    public class NocheObservacionInvalidaException : Exception
    {
        public NocheObservacionInvalidaException() 
            : base("La noche de observación no es válida.")
        {
        }

        public NocheObservacionInvalidaException(string mensaje)
            : base(mensaje)
        {
        }
    }
}