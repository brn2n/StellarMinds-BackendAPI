using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class AltaEquipo : ICUAlta<AltaEquipoDto>
    {
        private IRepositorioEquipo _repo;

        public AltaEquipo(IRepositorioEquipo repo)
        {
            _repo = repo;
        }
        public int Ejecutar(AltaEquipoDto obj)
        {
            if (obj == null)
            {
                throw new Exception("El Equipo no puede ser nulo");
            }

            return _repo.Add(EquipoMapper.FromDto(obj));
        }
    }
}
