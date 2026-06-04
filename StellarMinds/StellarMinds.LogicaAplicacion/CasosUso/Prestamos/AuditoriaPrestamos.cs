using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.Prestamos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.Prestamos
{
    public class AuditoriaPrestamos(IRepositorioAuditoriaPrestamo _repoAudi) : GetPrestamosByCoordinadorID<InfoAuditoriaPrestamosDto>
    {
        public IEnumerable<InfoAuditoriaPrestamosDto> Ejecutar(int t)
        {
            return AuditoriaPrestamosMapper.ToListDto(_repoAudi.GetByIdCoordinador(t));
        }
    }
}
