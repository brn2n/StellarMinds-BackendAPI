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
            NocheObservacion unaNocheObservacion = _nochesObservaciones.Find(n => n.Id == id);
            if (unaNocheObservacion == null)
            {
                throw new Exception("No se encontró la noche de observación con el ID proporcionado.");
            }
            return unaNocheObservacion;
        }
    }
}
