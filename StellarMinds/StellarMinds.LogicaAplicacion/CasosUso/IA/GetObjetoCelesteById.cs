using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.Infraestructura.InterfacesRepositorio.ObjetosCelestes;
using StellarMinds.LogicaAplicacion.Dtos.ObjetosCelestes;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.IA
{
    public class GetObjetoCelesteById : ICUGetById<ListarObjetoCelesteDto>
    {
        private readonly IRepositorioObjetosCelestes _repo;

        public GetObjetoCelesteById(IRepositorioObjetosCelestes repo)
        {
            _repo = repo;
        }

        public ListarObjetoCelesteDto Execute(int id)
        {
            var objeto = _repo.GetById(id);

            if (objeto == null)
                throw new NotFoundException("Objeto celeste no encontrado.");

            return ObjetoCelesteMapper.ToDto(objeto);
        }
    }
}
