namespace StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion
{
    public interface ICUPrestamosSociosEntreFechas<T>
    {
        public IEnumerable<T> Ejecutar(int socioId, int mes, int anio);
    }
}
