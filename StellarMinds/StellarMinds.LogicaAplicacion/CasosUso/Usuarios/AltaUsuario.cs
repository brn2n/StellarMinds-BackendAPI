using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using StellarMinds.LogicaNegocio.VO.VOUsuario;

namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class AltaUsuario : ICUAlta<AltaUsuarioDto>
    {
        private IRepositorioUsuario _repo;

        public AltaUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }
        public void Ejecutar(AltaUsuarioDto obj)
        {
            if (obj == null)
            {
                throw new Exception("El usuario no puede ser nulo");
            }

            _repo.Add(UsuarioMapper.FromDto(obj));
        }
    }
}
