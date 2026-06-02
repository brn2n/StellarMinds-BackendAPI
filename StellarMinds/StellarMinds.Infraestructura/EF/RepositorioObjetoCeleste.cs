using StellarMinds.Infraestructura.InterfacesRepositorio.ObjetosCelestes;
using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;

namespace StellarMinds.Infraestructura.EF
{
    public class RepositorioObjetoCeleste : IRepositorioObjetosCelestes
    {
        private StellarMindContext _context;

        public RepositorioObjetoCeleste(StellarMindContext context)
        {
            _context = context;
        }
        public int Add(ObjetoCeleste Obj)
        {
            if (Obj == null) throw new Exception("El objeto celeste no puede ser nulo.");
            _context.ObjetosCelestes.Add(Obj);
            _context.SaveChanges();
            return Obj.Id;
        }

        public IEnumerable<(ObjetoCeleste Objeto, int Cantidad)> GetRankingObjetosPuros()
        {
            return _context.NochesObservaciones
                .GroupBy(no => no.ObjetoCeleste)
                .Select(grupo => new
                {
                    Objeto = grupo.Key,
                    Cantidad = grupo.Count()
                })
                .OrderByDescending(x => x.Cantidad)
                .AsEnumerable()
                .Select(x => (x.Objeto, x.Cantidad))
                .ToList();
        }
        public IEnumerable<ObjetoCeleste> GetAll()
        {
            return _context.ObjetosCelestes;
        }

        public ObjetoCeleste GetById(int id)
        {
            ObjetoCeleste unObjetoCeleste = _context.ObjetosCelestes.Find(id);
            if (unObjetoCeleste == null) throw new Exception("El ObjetoCeleste no existe.");
            return unObjetoCeleste;
        }
    }
}
