using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

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
            return _repoPrestamo.GetAll()
                .Where(p =>
                    p.Socio.Id == socioId &&
                    p.FechaInicio.Month == mes &&
                    p.FechaInicio.Year == anio)
                .Select(p => new ListadoPrestamoSocioDto
                {
                    Id = p.Id,
                    FechaInicio = p.FechaInicio,
                    FechaFin = p.FechaFin,
                    Estado = p.Estado.ToString(),
                    EstaAtrasado = p.Estado == Estado.EN_PRESTAMO &&
                                    DateTime.Today > p.FechaFin.Date
                })
                .ToList();
        }
    }
}