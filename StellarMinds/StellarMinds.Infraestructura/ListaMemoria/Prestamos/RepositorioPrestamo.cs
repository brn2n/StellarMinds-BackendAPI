using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.Infraestructura.ListaMemoria.Prestamos
{
    public class RepositorioPrestamo : IRepositorioPrestamos
    {
        private static List<Prestamo> _prestamos { get; set; } = new List<Prestamo>();
        public void Add(Prestamo Obj)
        {
            _prestamos.Add(Obj);
        }

        public bool EnPrestamo(int id)
        {
            return _prestamos.Any(p => (p.Camara.Id == id
                                             || p.Telescopio.Id == id
                                             || p.Ocular.Id == id
                                             || p.Montura.Id == id)
                                             && p.Estado == Estado.EN_PRESTAMO);
        }

        public IEnumerable<Prestamo> GetAll()
        {
            return _prestamos;
        }
    }
}
