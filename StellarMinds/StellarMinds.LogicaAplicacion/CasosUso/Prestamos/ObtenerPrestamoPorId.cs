using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.Prestamos
{
    public class ObtenerPrestamoPorId : ICUGetById<ListadoPrestamoSocioDto>
    {
        private IRepositorioPrestamos _repo;

        public ObtenerPrestamoPorId(IRepositorioPrestamos repo)
        {
            _repo = repo;
        }

        public ListadoPrestamoSocioDto Execute(int id)
        {
            return PrestamoMapper.ToDto(_repo.GetById(id));
        }
    }
}
