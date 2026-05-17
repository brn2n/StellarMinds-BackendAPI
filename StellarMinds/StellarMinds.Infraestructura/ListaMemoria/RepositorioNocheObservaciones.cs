using StellarMinds.Infraestructura.InterfacesRepositorio.NochesObservaciones;
using StellarMinds.LogicaNegocio.Entidades.NochesObservaciones;

namespace StellarMinds.Infraestructura.ListaMemoria
{
    public class RepositorioNocheObservaciones : IRepositorioNochesObservaciones
    {
        private static List<NocheObservacion> _nochesObservaciones { get; set; } = new List<NocheObservacion>();
        public void Add(NocheObservacion Obj)
        {
            _nochesObservaciones.Add(Obj);
        }

        public IEnumerable<NocheObservacion> GetAll()
        {
            return _nochesObservaciones;
        }

        public NocheObservacion GetById(int id)
        {
            return _nochesObservaciones.Find(n => n.Id == id);
        }
    }
}
