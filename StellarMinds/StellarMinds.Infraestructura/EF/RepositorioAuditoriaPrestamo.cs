using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.Infraestructura.EF
{
    public class RepositorioAuditoriaPrestamo : IRepositorioAuditoriaPrestamo
    {
        private readonly StellarMindContext _context;

        public RepositorioAuditoriaPrestamo(StellarMindContext context)
        {
            _context = context;
        }

        public int Add(AuditoriaPrestamo Obj)
        {
            if (Obj == null) throw new Exception("El Auditoria no puede ser nula.");
            _context.AuditoriasPrestamos.Add(Obj);
            _context.SaveChanges();
            return Obj.Id;

        }

        public IEnumerable<AuditoriaPrestamo> GetByIdCoordinador(int id)
        {
            return _context.AuditoriasPrestamos.Where(a => a.Prestamo.SocioId == id).ToList();
        }
    }
}