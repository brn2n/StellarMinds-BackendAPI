using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;

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
            return _repoPrestamo.GetAll()
                .Select(p => new ListadoPrestamoSocioDto
                {
                    Id = p.Id,
                    SocioId = p.SocioId,
                    FechaInicio = p.FechaInicio,
                    FechaFin = p.FechaFin,
                    Estado = p.Estado.ToString(),
                    EstaAtrasado = p.Estado.ToString() == "EN_PRESTAMO"
                                   && DateTime.Today > p.FechaFin.Date
                })
                .ToList();
        }
    }
}