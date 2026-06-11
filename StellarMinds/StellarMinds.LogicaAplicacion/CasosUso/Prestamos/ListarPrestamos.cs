using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.PrestamoCU
{
    public class ListarPrestamos : ICUGetAll<ListadoPrestamoSocioDto>
    {
        private readonly IRepositorioPrestamos _repoPrestamo;

        public ListarPrestamos(IRepositorioPrestamos repoPrestamo)
        {
            _repoPrestamo = repoPrestamo;
        }

        public IEnumerable<ListadoPrestamoSocioDto> Ejecutar()
        {
            return PrestamoMapper.ToListDto(_repoPrestamo.GetAll());
        }
    }
}