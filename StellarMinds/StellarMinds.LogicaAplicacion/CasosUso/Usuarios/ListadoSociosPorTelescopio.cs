using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class ListadoSociosPorTelescopio(IRepositorioUsuario _repo) : ICUGetByTelescopio<ListarUsuariosDto>
    {
        public IEnumerable<ListarUsuariosDto> Ejecutar(int t)
        {
            if (t <= 0)
            {
                throw new ArgumentException("El Id no es valido");
            }
            return UsuarioMapper.ToListDto(_repo.GetUsuariosPorTelescopio(t));
        }
    }
}
