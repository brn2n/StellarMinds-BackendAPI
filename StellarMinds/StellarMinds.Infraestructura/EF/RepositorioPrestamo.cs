using StellarMinds.Infraestructura.EF.Exceptions;
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
            if (Obj == null) throw new Exception("El préstamo no puede ser nulo.");//NUCNA NEW EXPECTION GENERICA
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

        public bool FueUsadoEnPrestamo(int id)
        {
            return _context.Prestamos.Any(p =>
                (p.Telescopio != null && p.Telescopio.Id == id) ||
                (p.Montura != null && p.Montura.Id == id) ||
                (p.Camara != null && p.Camara.Id == id) ||
                (p.Ocular != null && p.Ocular.Id == id)
            );
        }

        public IEnumerable<Prestamo> GetAll()
        {
            return _context.Prestamos.ToList();
        }

        public Prestamo GetById(int id)
        {
            Prestamo unPrestamo = _context.Prestamos.Find(id);
            if (unPrestamo == null) throw new NotFoundException("El prestamo no existe.");
            return unPrestamo;
        }

        public IEnumerable<Prestamo> GetPrestamosEnPrestamoPorSocio(int socioId)
        {
            return _context.Prestamos
                .Where(p => p.SocioId == socioId && p.Estado == Estado.EN_PRESTAMO)
                .ToList();
        }

        public IEnumerable<Prestamo> ListarEntreFechas(int socioId, int mes, int anio)
        {
            return _context.Prestamos
                .Where(p =>
                    p.SocioId == socioId &&
                    p.FechaInicio.Month == mes &&
                    p.FechaInicio.Year == anio)
                .ToList();
        }

        public void Update(int id, Prestamo obj)
        {
            _context.Prestamos.Update(obj);
            _context.SaveChanges();
        }
    }
}

