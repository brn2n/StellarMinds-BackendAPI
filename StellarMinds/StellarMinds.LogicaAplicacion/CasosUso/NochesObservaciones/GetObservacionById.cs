using StellarMinds.Infraestructura.InterfacesRepositorio.NochesObservaciones;
using StellarMinds.LogicaAplicacion.Dtos.NochesObservaciones;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.NochesObservaciones
{
    public class GetObservacionById(IRepositorioNochesObservaciones _repo) : ICUGetById<AltaObservacionDto>
    {
        public AltaObservacionDto Execute(int id)
        {
            return NocheObservacionMapper.toDto(_repo.GetById(id));
        }
    }
}
