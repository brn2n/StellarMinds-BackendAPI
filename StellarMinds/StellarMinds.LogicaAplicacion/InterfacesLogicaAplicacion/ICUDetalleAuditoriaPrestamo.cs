namespace StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion
{
    public interface ICUDetalleAuditoriaPrestamo<T>
    {
        IEnumerable<T> Ejecutar(int prestamoId);
    }
}
