using StellarMinds.Infraestructura.InterfacesRepositorio.ObjetosCelestes;
using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;

namespace StellarMinds.Infraestructura.EF
{
    public class RepositorioObjetoCeleste : IRepositorioObjetosCelestes
    {
        StellarMindContext _context = new StellarMindContext();
        public void Add(ObjetoCeleste Obj)
        {
            if (Obj == null) throw new Exception("El objeto celeste no puede ser nulo.");
            _context.ObjetosCelestes.Add(Obj);
            _context.SaveChanges();
        }

        public IEnumerable<ObjetoCeleste> GetAll()
        {
            return _context.ObjetosCelestes;
        }

        public ObjetoCeleste GetById(int id)
        {
            return _context.ObjetosCelestes.Find(id);
        }
    }
}
