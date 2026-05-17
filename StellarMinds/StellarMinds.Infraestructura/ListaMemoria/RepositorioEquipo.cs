using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.Infraestructura.ListaMemoria
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private static List<Equipo> _equipos { get; set; } = new List<Equipo>();

        public void Add(Equipo equipo)
        {
            _equipos.Add(equipo);
        }

        public void Delete(int id)
        {
            Equipo unEquipo = GetById(id);
            _equipos.Remove(unEquipo);
        }

        public IEnumerable<Equipo> GetAll()
        {
            return _equipos;
        }

        public Equipo GetById(int id)
        {
            Equipo unEquipo = _equipos.Find(e => e.Id == id);
            if (unEquipo == null)
            {
                throw new Exception($"No se encontro el equipo {id}");
            }
            return unEquipo;
        }

        public void Update(int id, Equipo obj)
        {
            Equipo unEquipo = GetById(id);
            unEquipo.Update(obj);
        }
    }
}
