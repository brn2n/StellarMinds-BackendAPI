namespace StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion
{
    public interface ICUGetByTelescopio<T>
    {
        public IEnumerable<T> Ejecutar(int t);
    }
}
