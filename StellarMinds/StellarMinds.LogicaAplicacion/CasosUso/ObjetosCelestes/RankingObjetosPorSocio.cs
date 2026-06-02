using StellarMinds.Infraestructura.InterfacesRepositorio.ObjetosCelestes;
using StellarMinds.LogicaAplicacion.Dtos.ObjetosCelestes;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.ObjetosCelestes
{
    public class RankingObjetosPorSocio(IRepositorioObjetosCelestes _repo) : ICUGetAll<RankingObjetosPorSocioDto>
    {
        public IEnumerable<RankingObjetosPorSocioDto> Ejecutar()
        {
            return ObjetoCelesteMapper.ToListDto(_repo.GetRankingObjetosPuros());
        }
    }
}
