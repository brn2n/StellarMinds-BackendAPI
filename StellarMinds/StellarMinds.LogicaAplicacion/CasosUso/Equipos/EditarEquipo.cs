using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class EditarEquipo : ICUEdit<ListarEquipoDto>
    {
        private IRepositorioEquipo _repo;

        public EditarEquipo(IRepositorioEquipo repo)
        {
            _repo = repo;
        }

        public void Execute(int id, ListarEquipoDto Obj)
        {
            _repo.Update(id,EquipoMapper.FromDto(Obj));
        }
    }
}
