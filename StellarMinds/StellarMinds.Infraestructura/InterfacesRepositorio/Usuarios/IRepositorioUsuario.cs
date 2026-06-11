using StellarMinds.LogicaNegocio.Entidades.Usuarios;

namespace StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios
{
    public interface IRepositorioUsuario : IRepositorioGetAll<Usuario>, IRepositorioAdd<Usuario>, IRepositorioGetById<Usuario>
    {
        public IEnumerable<Usuario> GetUsuariosPorTelescoio(int id);
        public Usuario GetCoordinadorById(int id);
        public IEnumerable<Socio> ObtenerTodosLosSocios();
        public IEnumerable<Coordinador> ObtenerTodosLosCoordinadores();
        public Usuario LogInAuth(string username, string password);
        bool ExisteCoordinador(int id);
    }
}
