using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos
{
    public interface IRepositorioAuditoriaPrestamo : IRepositorioAdd<AuditoriaPrestamo>
    {
        IEnumerable<AuditoriaPrestamo> GetAll();
        IEnumerable<AuditoriaPrestamo> GetByIdCoordinador(int id);
        IEnumerable<AuditoriaPrestamo> GetByIdPrestamo(int prestamoId);
    }
}
