namespace StellarMinds.LogicaAplicacion.CUExceptions.CUEquipo
{
    public class equipoNoOcularException : Exception
    {
        public equipoNoOcularException()
            : base("El equipo no es Ocular")
        {
        }

        public equipoNoOcularException(string mensaje)
            : base(mensaje)
        {
        }
    }
}