namespace StellarMinds.LogicaAplicacion.CUExceptions.CUPrestamo
{
    public class PrestamoNuloException : Exception
    {
        public PrestamoNuloException()
            : base("El préstamo no puede ser nulo.")
        {
        }

        public PrestamoNuloException(string mensaje)
            : base(mensaje)
        {
        }
    }
}