namespace StellarMinds.LogicaAplicacion.CUExceptions.CUEquipo
{
    public class equipoNoDisponibleException : Exception
    {
        public equipoNoDisponibleException(string mensaje)
            : base(mensaje)
        {
        }

        public equipoNoDisponibleException()
            : base("El equipo no está disponible.")
        {
        }
    }
}