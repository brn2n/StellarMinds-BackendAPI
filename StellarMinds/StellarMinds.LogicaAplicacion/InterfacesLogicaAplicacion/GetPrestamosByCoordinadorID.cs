namespace StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion
{
    public interface GetPrestamosByCoordinadorID<T>
    {
        public IEnumerable<T> Ejecutar(int t);
    }
}
