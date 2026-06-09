using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.Infraestructura.EF
{
    public class RepositorioEquipo : IRepositorioEquipo
    {

        private StellarMindContext _context;
        public RepositorioEquipo(StellarMindContext context)
        {
            _context = context;
        }

        public int Add(Equipo Obj)
        {
            if (Obj == null) throw new Exception("El equipo no puede ser nulo.");
            Obj.Validar();
            _context.Equipos.Add(Obj);
            _context.SaveChanges();
            return Obj.Id;
        }

        public void Delete(int id)
        {
            Equipo equipo = _context.Equipos.Find(id);

            if (equipo == null)
                throw new NotFoundException("No existe el equipo.");

            _context.Equipos.Remove(equipo);
            _context.SaveChanges();
        }

        public IEnumerable<Equipo> GetTelescopios()
        {
            return _context.Equipos.OfType<Telescopio>().ToList();
        }

        public IEnumerable<Equipo> GetAll()
        {
            return _context.Equipos.ToList();
        }

        public Equipo GetById(int id)
        {
            Equipo unEquipo = _context.Equipos.Find(id);
            if (unEquipo == null) throw new NotFoundException("El equipo no existe.");
            return unEquipo;
        }

        public void Update(int id, Equipo obj)
        {
            Equipo unEquipo = GetById(id);
            unEquipo.Update(obj);
            _context.Equipos.Update(unEquipo);
            _context.SaveChanges();
        }
    }
}
