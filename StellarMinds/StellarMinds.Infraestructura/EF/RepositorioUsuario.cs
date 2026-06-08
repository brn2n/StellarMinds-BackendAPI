using Microsoft.EntityFrameworkCore;
using StellarMinds.Infraestructura.EF.Exceptions;
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
            var socios = _context.Prestamos
                .Include(p => p.Socio)
                .Where(p => p.TelescopioId == id)
                .Select(p => p.Socio)
                .ToList();

            return socios
                .GroupBy(s => s.Id)
                .Select(g => g.First())
                .OrderByDescending(s => s.NombreCompleto.Nombre)
                .ToList();
        }

        public Usuario GetCoordinadorById()
        {
            Usuario unUsuario = _context.Usuarios.OfType<Coordinador>().FirstOrDefault();
            if (unUsuario == null) throw new Exception("No existe un coordinador registrado.");
            return unUsuario;
        }

        public Usuario GetById(int id)
        {
            Usuario unUsuario = _context.Usuarios.Find(id);
            if (unUsuario == null) throw new NotFoundException("El Usuario no existe.");
            return unUsuario;
        }


    }
}
