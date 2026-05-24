namespace StellarMinds.LogicaAplicacion.CUExceptions.CUEquipo
{
    public class equipoNoTelescopioException : Exception
    {
        public equipoNoTelescopioException()
            : base("El equipo no es Telescopio")
        {
        }

        public equipoNoTelescopioException(string mensaje)
            : base(mensaje)
        {
        }
    }
}