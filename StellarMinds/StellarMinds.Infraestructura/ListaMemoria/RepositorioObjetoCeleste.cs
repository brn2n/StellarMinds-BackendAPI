using StellarMinds.Infraestructura.InterfacesRepositorio.ObjetosCelestes;
using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;

namespace StellarMinds.Infraestructura.ListaMemoria
{
    public class RepositorioObjetoCeleste : IRepositorioObjetosCelestes
    {
        private static List<ObjetoCeleste> _objetosCelestes { get; set; } = new List<ObjetoCeleste>();
        public int Add(ObjetoCeleste Obj)
        {
            if (Obj == null) throw new Exception("El objeto celeste no puede ser nulo.");
            _objetosCelestes.Add(Obj);
            return Obj.Id;
        }

        public IEnumerable<ObjetoCeleste> GetAll()
        {
            return _objetosCelestes;
        }

        public ObjetoCeleste GetById(int id)
        {
            ObjetoCeleste unObjetoCeleste = _objetosCelestes.Find(o => o.Id == id);
            if (unObjetoCeleste == null) throw new Exception("No se encontró el objeto celeste con el ID proporcionado.");
            return unObjetoCeleste;
        }

        public IEnumerable<(ObjetoCeleste Objeto, int Cantidad)> GetRankingObjetosPuros()
        {
            throw new NotImplementedException();
        }
    }
}
