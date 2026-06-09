using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.Infraestructura.InterfacesRepositorio.NochesObservaciones;
using StellarMinds.LogicaNegocio.Entidades.NochesObservaciones;

namespace StellarMinds.Infraestructura.EF
{
    public class RepositorioNocheObservaciones : IRepositorioNochesObservaciones
    {

        private StellarMindContext _context;
        public RepositorioNocheObservaciones(StellarMindContext context)
        {
            _context = context;
        }
        public int Add(NocheObservacion Obj)
        {
            if (Obj == null) throw new Exception("La noche de observación no puede ser nula.");
            _context.NochesObservaciones.Add(Obj);
            _context.SaveChanges();
            return Obj.Id;
        }
        public IEnumerable<NocheObservacion> GetAll()
        {
            return _context.NochesObservaciones.ToList();
        }

        public NocheObservacion GetById(int id)
        {
            NocheObservacion unaNocheObservacion = _context.NochesObservaciones.Find(id);
            if (unaNocheObservacion == null) throw new NotFoundException("La NocheObservacion no existe.");
            return unaNocheObservacion;
        }
    }
}
