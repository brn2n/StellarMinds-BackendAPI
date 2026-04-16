using StellarMinds.Infraestructura.InterfacesRepositorio;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using StellarMinds.LogicaNegocio.VO.VOUsuario;


namespace StellarMinds.LogicaAplicacion.CasosUso.Usuarios
{
    public class AltaSocio : ICUAlta<AltaSocioDto>
    {
        private IRepositorioSocio _repo;

        public AltaSocio(IRepositorioSocio repo)
        {
            _repo = repo;
        }

        public void Ejecutar(AltaSocioDto usuario)
        {
            if (usuario == null)
            {
                throw new Exception("El usuario no puede ser nulo");
            }
            _repo.Add(new Socio(usuario.Id, new VONombreCompleto(usuario.nombre, usuario.apellido), new VOTelefono(usuario.telefono), new VOUsername(usuario.username), new VOPassword(usuario.password)));
        }
    }
}
