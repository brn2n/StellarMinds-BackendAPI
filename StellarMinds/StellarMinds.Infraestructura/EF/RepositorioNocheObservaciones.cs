using StellarMinds.Infraestructura.InterfacesRepositorio.NochesObservaciones;
using StellarMinds.LogicaNegocio.Entidades.NochesObservaciones;

namespace StellarMinds.Infraestructura.EF
{
    public class RepositorioNocheObservaciones : IRepositorioNochesObservaciones
    {
        StellarMindContext _context = new StellarMindContext();
        public void Add(NocheObservacion Obj)
        {
            if (Obj == null) throw new Exception("La noche de observación no puede ser nula.");
            _context.NochesObservaciones.Add(Obj);
            _context.SaveChanges();
        }

        public IEnumerable<NocheObservacion> GetAll()
        {
            return _context.NochesObservaciones.ToList();
        }

        public NocheObservacion GetById(int id)
        {
            return _context.NochesObservaciones.Find(id);
        }
    }
}
