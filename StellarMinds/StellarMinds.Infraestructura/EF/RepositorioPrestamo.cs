namespace StellarMinds.Infraestructura.EF
{
    //public class RepositorioPrestamo : IRepositorioPrestamos
    //{
    //    StellarMindContext _context = new StellarMindContext();
    //    public void Add(Prestamo Obj)
    //    {
    //        if (Obj == null) throw new Exception("El préstamo no puede ser nulo.");
    //        _context.Prestamos.Add(Obj);
    //        _context.SaveChanges();
    //    }

    //    public bool EnPrestamo(int id)
    //    {
    //        return _context.Prestamos.Any(p => (p.Camara.Id == id
    //                                         || p.Telescopio.Id == id
    //                                         || p.Ocular.Id == id
    //                                         || p.Montura.Id == id)
    //                                         && p.Estado == Estado.EN_PRESTAMO);
    //    }

    //    public IEnumerable<Prestamo> GetAll()
    //    {
    //        return _context.Prestamos.ToList();
    //    }
}

