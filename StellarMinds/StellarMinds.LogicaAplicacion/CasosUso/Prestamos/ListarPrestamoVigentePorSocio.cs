using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.Prestamos
{
    public class ListarPrestamoVigentePorSocio
    : ICUPrestamosVigentes<ListadoPrestamoSocioDto>
    {
        private readonly IRepositorioPrestamos _repoPrestamos;

        public ListarPrestamoVigentePorSocio(IRepositorioPrestamos repoPrestamos)
        {
            _repoPrestamos = repoPrestamos;
        }

        public IEnumerable<ListadoPrestamoSocioDto> Execute(int socioId)
        {
            var prestamos = _repoPrestamos.GetPrestamosEnPrestamoPorSocio(socioId);

            return PrestamoMapper.ToListDto(_repoPrestamos.GetPrestamosVigentesPorSocio(socioId));
        }
    }
}
