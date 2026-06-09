using StellarMinds.LogicaNegocio.Entidades.Usuarios;

namespace StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios
{
    public interface IRepositorioUsuario : IRepositorioGetAll<Usuario>, IRepositorioAdd<Usuario>, IRepositorioGetById<Usuario>
    {
        public IEnumerable<Usuario> GetUsuariosPorTelescoio(int id);
        public Usuario LogInAuth(string username, string password);
    }
}
