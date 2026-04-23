using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class ListarEquipos : ICUGetAll<Equipo>
    {
        private IRepositorioEquipo _repo;

        public ListarEquipos(IRepositorioEquipo repo)
        {
            _repo = repo;
        }

        public IEnumerable<Equipo> Ejecutar()
        {
            return _repo.GetAll();
        }
    }
}
