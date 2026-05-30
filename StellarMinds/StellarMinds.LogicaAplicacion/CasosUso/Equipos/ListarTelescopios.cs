using StellarMinds.Infraestructura.EF;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class ListarTelescopios (RepositorioEquipo _repo) : ICUGetAll<ListarEquipoDto>
    {
        public IEnumerable<ListarEquipoDto> Ejecutar()
        {
            return EquipoMapper.ToListDto(_repo.GetTelescopios());
        }
    }
}
