using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.IA
{
    public class GetEquipoByIdDto : ICUGetById<ListarEquipoDto>
    {
        private readonly IRepositorioEquipo _repo;

        public GetEquipoByIdDto(IRepositorioEquipo repo)
        {
            _repo = repo;
        }

        public ListarEquipoDto Execute(int id)
        {
            var equipo = _repo.GetById(id);

            if (equipo == null)
                throw new NotFoundException("Equipo no encontrado.");

            return EquipoMapper.toDto(equipo);
        }
    }
}
