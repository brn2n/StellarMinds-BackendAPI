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
            if (Obj == null) throw new Exception("El equipo no puede ser nulo.");
            _context.AuditoriasPrestamos.Add(Obj);
            _context.SaveChanges();
            return Obj.Id;

        }
    }
}