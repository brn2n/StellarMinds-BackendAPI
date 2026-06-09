using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.Prestamos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.Prestamos
{
    public class ObtenerPrestamoPorId : ICUGetById<InfoAuditoriaPrestamosDto>
    {
        private IRepositorioAuditoriaPrestamo _repo;

        public ObtenerPrestamoPorId(IRepositorioAuditoriaPrestamo repo)
        {
            _repo = repo;
        }

        public InfoAuditoriaPrestamosDto Execute(int id)
        {
            return AuditoriaPrestamosMapper.ToDto(_repo.GetById(id));
        }
    }
}
