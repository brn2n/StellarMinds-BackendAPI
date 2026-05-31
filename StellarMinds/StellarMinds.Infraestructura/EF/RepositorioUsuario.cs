using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;

namespace StellarMinds.Infraestructura.EF
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private StellarMindContext _context;
        public RepositorioUsuario(StellarMindContext context)
        {
            _context = context;
        }
        public int Add(Usuario Obj)
        {
            if (Obj == null) throw new Exception("El usuario no puede ser nulo.");
            _context.Usuarios.Add(Obj);
            _context.SaveChanges();
            return Obj.Id;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public IEnumerable<Usuario> GetUsuariosPorTelescoio(int id)
        {
            return _context.Prestamos.Where(p => p.TelescopioId == id).Select(p => p.Socio).Distinct().OrderByDescending(u => u.NombreCompleto.Nombre).ToList();
        }

        public Usuario GetById(int id)
        {
            Usuario unUsuario = _context.Usuarios.Find(id);
            if (unUsuario == null) throw new Exception("El Usuario no existe.");
            return unUsuario;
        }

        public IEnumerable<Usuario> GetUsuariosPorTelescopio(int id)
        {
            throw new NotImplementedException();
        }
    }
}
