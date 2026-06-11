using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaAplicacion.Dtos.Prestamos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.PrestamoCU
{
    public class ListarAuditoriaPrestamos :
        ICUListarAuditoriaPrestamos<InfoAuditoriaPrestamosDto>
    //ICUDetalleAuditoriaPrestamo<InfoAuditoriaPrestamosDto>
    {
        private readonly IRepositorioAuditoriaPrestamo _repoAudi;
        private readonly IRepositorioUsuario _repoUsuario;

        public ListarAuditoriaPrestamos(IRepositorioAuditoriaPrestamo repoAudi, IRepositorioUsuario repoUsuario)
        {
            _repoAudi = repoAudi;
            _repoUsuario = repoUsuario;
        }

        public IEnumerable<InfoAuditoriaPrestamosDto> Ejecutar(int coordinadorId)
        {
            if (!_repoUsuario.ExisteCoordinador(coordinadorId))
            {
                throw new NotFoundException("No existe ese coordinador");
            }

            return AuditoriaPrestamosMapper.ToListDto(_repoAudi.GetByIdCoordinador(coordinadorId));
        }

        //public IEnumerable<InfoAuditoriaPrestamosDto> Ejecutar(int prestamoId)
        //{
        //    return AuditoriaPrestamosMapper.ToListDto(_repoAudi.GetByIdPrestamo(prestamoId));
        //}
    }
}
