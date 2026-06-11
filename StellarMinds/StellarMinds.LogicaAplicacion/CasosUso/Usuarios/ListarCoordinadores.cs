using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class ListarCoordinadores(IRepositorioUsuario _repo) : ICUGetAllCoordinadores<ListarUsuariosDto>
    {
        public IEnumerable<ListarUsuariosDto> Ejecutar()
        {
            return UsuarioMapper.ToListDto(_repo.ObtenerTodosLosCoordinadores());
        }
    }
}
