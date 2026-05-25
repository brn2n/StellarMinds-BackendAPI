using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;

namespace StellarMinds.Infraestructura.ListaMemoria
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private static List<Usuario> _usuario { get; set; } = new List<Usuario>();

        public int Add(Usuario Obj)
        {
            _usuario.Add(Obj);
            return Obj.Id;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuario;
        }
    }
}
