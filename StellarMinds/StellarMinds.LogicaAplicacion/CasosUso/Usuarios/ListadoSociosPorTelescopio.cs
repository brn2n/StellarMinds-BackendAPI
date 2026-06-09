using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class ListadoSociosPorTelescopio : ICUGetByTelescopio<ListarUsuariosDto>
    {
        private readonly IRepositorioUsuario _repo;

        public ListadoSociosPorTelescopio(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public IEnumerable<ListarUsuariosDto> Ejecutar(int telescopioId)
        {
            if (telescopioId == 0)
            {
                throw new ArgumentException("El Id del telescopio no es válido.");
            }  

            return UsuarioMapper.ToListDto(
                _repo.GetUsuariosPorTelescoio(telescopioId)
            );
        }
    }
}