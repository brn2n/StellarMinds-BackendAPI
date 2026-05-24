namespace StellarMinds.LogicaAplicacion.CUExceptions.CUEquipo
{
    public class equipoNoMonturaException : Exception
    {
        public equipoNoMonturaException()
            : base("El equipo no es Telescopio")
        {
        }

        public equipoNoMonturaException(string mensaje)
            : base(mensaje)
        {
        }
    }
}