using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos
{
    public interface IRepositorioAuditoriaPrestamo : IRepositorioAdd<AuditoriaPrestamo>
    {
        public IEnumerable<AuditoriaPrestamo> GetByIdCoordinador(int id);
    }
}