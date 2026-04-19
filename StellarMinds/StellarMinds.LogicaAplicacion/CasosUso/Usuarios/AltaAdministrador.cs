using StellarMinds.Infraestructura.InterfacesRepositorio;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using StellarMinds.LogicaNegocio.VO.VOUsuario;


namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class AltaAdministrador : ICUAlta<AltaAdministradorDto>
    {
        private IRepositorioSocio _repo;

        public AltaAdministrador(IRepositorioSocio repo)
        {
            _repo = repo;
        }

        public void Ejecutar(AltaAdministradorDto usuario)
        {
            if (usuario == null)
            {
                throw new Exception("El usuario no puede ser nulo");
            }
            _repo.Add(new AltaAdministrador(usuario.Id, new VONombreCompleto(usuario.nombre, usuario.apellido), new VOTelefono(usuario.telefono), new VOUsername(usuario.username), new VOPassword(usuario.password)));
        }
    }
}
