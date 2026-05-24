namespace StellarMinds.LogicaAplicacion.CUExceptions.CUEquipo
{
    public class equipoNoDisponibleException : Exception
    {
        public equipoNoDisponibleException()
            : base("El equipo no es Telescopio")
        {
        }

        public equipoNoDisponibleException(string mensaje)
            : base(mensaje)
        {
        }
    }
}