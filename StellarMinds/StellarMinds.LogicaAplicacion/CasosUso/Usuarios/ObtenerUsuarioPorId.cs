using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class ObtenerUsuarioPorId(IRepositorioUsuario _repo) : ICUGetById<AltaUsuarioDto>
    {
        public AltaUsuarioDto Execute(int id)
        {
            return UsuarioMapper.toDtoGet(_repo.GetById(id));
        }
    }
}
