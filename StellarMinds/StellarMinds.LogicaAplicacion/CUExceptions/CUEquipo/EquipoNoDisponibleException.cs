namespace StellarMinds.LogicaAplicacion.CUExceptions.CUEquipo
{
    public class equipoNoDisponibleException : Exception
    {
        public equipoNoDisponibleException()
            : base("El equipo no Disponible")
        {
        }

        public equipoNoDisponibleException(string mensaje)
            : base(mensaje)
        {
        }
    }
}