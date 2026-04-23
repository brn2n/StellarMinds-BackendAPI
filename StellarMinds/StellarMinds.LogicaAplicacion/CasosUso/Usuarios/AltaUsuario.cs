using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
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

            if (obj.rol == "Socio") {
                _repo.Add(new Socio(obj.Id, new VONombreCompleto(obj.nombre, obj.apellido), new VOTelefono(obj.telefono), new VOUsername(obj.username), new VOPassword(obj.password)));
            }

            if (obj.rol == "Administrador")
            {
                _repo.Add(new Administrador(obj.Id, new VONombreCompleto(obj.nombre, obj.apellido), new VOTelefono(obj.telefono), new VOUsername(obj.username), new VOPassword(obj.password)));
            }

            if (obj.rol == "Coordinador")
            {
                _repo.Add(new Coordinador(obj.Id, new VONombreCompleto(obj.nombre, obj.apellido), new VOTelefono(obj.telefono), new VOUsername(obj.username), new VOPassword(obj.password)));
            }
        }
    }
}
