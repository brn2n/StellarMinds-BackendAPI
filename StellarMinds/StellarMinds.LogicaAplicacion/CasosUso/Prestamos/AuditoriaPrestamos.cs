using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.Prestamos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.PrestamoCU
{
    public class AuditoriaPrestamos :
        ICUListarAuditoriaPrestamos<InfoAuditoriaPrestamosDto>,
        ICUDetalleAuditoriaPrestamo<InfoAuditoriaPrestamosDto>
    {
        private readonly IRepositorioAuditoriaPrestamo _repoAudi;

        public AuditoriaPrestamos(IRepositorioAuditoriaPrestamo repoAudi)
        {
            _repoAudi = repoAudi;
        }

        public IEnumerable<InfoAuditoriaPrestamosDto> Ejecutar(int? coordinadorId)
        {
            var auditorias = coordinadorId.HasValue
                ? _repoAudi.GetByIdCoordinador(coordinadorId.Value)
                : _repoAudi.GetAll();

            return AuditoriaPrestamosMapper.ToListDto(auditorias);
        }

        public IEnumerable<InfoAuditoriaPrestamosDto> Ejecutar(int prestamoId)
        {
            return AuditoriaPrestamosMapper.ToListDto(_repoAudi.GetByIdPrestamo(prestamoId));
        }
    }
}
