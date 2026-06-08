using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class AltaUsuario : ICUAlta<AltaUsuarioDto>
    {
        private IRepositorioUsuario _repo;

        public AltaUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }
        public int Ejecutar(AltaUsuarioDto obj)
        {
            if (obj == null)
            {
                throw new Exception("El usuario no puede ser nulo");
            }

            return _repo.Add(UsuarioMapper.FromDto(obj));
        }
    }
}
