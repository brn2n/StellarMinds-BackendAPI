using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.PrestamoCU
{
    public class ListarPrestamosSocioEntreFechas : ICUPrestamosSociosEntreFechas<ListadoPrestamoSocioDto>
    {
        private readonly IRepositorioPrestamos _repoPrestamo;

        public ListarPrestamosSocioEntreFechas(IRepositorioPrestamos repoPrestamo)
        {
            _repoPrestamo = repoPrestamo;
        }

        public IEnumerable<ListadoPrestamoSocioDto> Ejecutar(int socioId, int mes, int anio)
        {
            return PrestamoMapper.ToListDto(_repoPrestamo.ListarEntreFechas(socioId, mes, anio));
        }
    }
}