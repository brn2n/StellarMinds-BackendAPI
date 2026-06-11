namespace StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion
{
    public interface ICUListarAuditoriaPrestamos<T>
    {
        IEnumerable<T> Ejecutar(int coordinadorId);
    }
}
