using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<AuditoriaPrestamo> GetAll()
        {
            return _context.AuditoriasPrestamos
                .Include(a => a.Coordinador)
                .Include(a => a.Prestamo)
                .OrderByDescending(a => a.Fecha)
                .ToList();
        }

        public IEnumerable<AuditoriaPrestamo> GetByIdCoordinador(int id)
        {
            return _context.AuditoriasPrestamos
                .Include(a => a.Coordinador)
                .Include(a => a.Prestamo)
                .Where(a => a.CoordinadorId == id)
                .OrderByDescending(a => a.Fecha)
                .ToList();
        }

        public IEnumerable<AuditoriaPrestamo> GetByIdPrestamo(int prestamoId)
        {
            return _context.AuditoriasPrestamos
                .Include(a => a.Coordinador)
                .Include(a => a.Prestamo)
                .Where(a => a.PrestamoId == prestamoId)
                .OrderByDescending(a => a.Fecha)
                .ToList();
        }
    }
}