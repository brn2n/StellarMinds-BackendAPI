using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class ListarEquipos : ICUGetAll<ListarEquipoDto>
    {
        private IRepositorioEquipo _repo;

        public ListarEquipos(IRepositorioEquipo repo)
        {
            _repo = repo;
        }

        public IEnumerable<ListarEquipoDto> Ejecutar()
        {
            return EquipoMapper.ToListDto(_repo.GetAll());
        }
    }
}
