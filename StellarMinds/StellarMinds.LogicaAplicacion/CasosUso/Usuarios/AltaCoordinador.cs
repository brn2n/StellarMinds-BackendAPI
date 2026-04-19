using StellarMinds.Infraestructura.InterfacesRepositorio;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using StellarMinds.LogicaNegocio.VO.VOUsuario;


namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class AltaCoordinador : ICUAlta<AltaCoordinadorDto>
    {
        private IRepositorioSocio _repo;

        public AltaCoordinador(IRepositorioSocio repo)
        {
            _repo = repo;
        }

        public void Ejecutar(AltaCoordinadorDto usuario)
        {
            if (usuario == null)
            {
                throw new Exception("El usuario no puede ser nulo");
            }
            _repo.Add(new Coordinador(usuario.Id, new VONombreCompleto(usuario.nombre, usuario.apellido), new VOTelefono(usuario.telefono), new VOUsername(usuario.username), new VOPassword(usuario.password)));
        }
    }
}
