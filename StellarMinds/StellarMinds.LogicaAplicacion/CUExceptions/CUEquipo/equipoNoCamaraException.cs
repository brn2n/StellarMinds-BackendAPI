namespace StellarMinds.LogicaAplicacion.CUExceptions.CUEquipo
{
    public class equipoNoCamaraException : Exception
    {
        public equipoNoCamaraException()
            : base("El equipo no es Telescopio")
        {
        }

        public equipoNoCamaraException(string mensaje)
            : base(mensaje)
        {
        }
    }
}