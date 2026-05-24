using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.Infraestructura.EF
{
    public class RepositorioPrestamo : IRepositorioPrestamos
    {
        private StellarMindContext _context;
        public RepositorioPrestamo(StellarMindContext context)
        {
            _context = context;
        }

        public int Add(Prestamo Obj)
        {
            if (Obj == null) throw new Exception("El préstamo no puede ser nulo.");
            _context.Prestamos.Add(Obj);
            _context.SaveChanges();
            return Obj.Id;
        }

        public bool EnPrestamo(int id)
        {
            return _context.Prestamos.Any(p => (p.Camara.Id == id
                                             || p.Telescopio.Id == id
                                             || p.Ocular.Id == id
                                             || p.Montura.Id == id)
                                             && p.Estado == Estado.EN_PRESTAMO);
        }

        public IEnumerable<Prestamo> GetAll()
        {
            return _context.Prestamos.ToList();
        }

        public Prestamo GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

