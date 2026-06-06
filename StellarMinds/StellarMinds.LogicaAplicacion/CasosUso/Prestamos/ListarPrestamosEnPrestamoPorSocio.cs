using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;

public class ListarPrestamosEnPrestamoPorSocio
    : ICUListarPrestamosEnPrestamoPorSocio<ListadoPrestamoSocioDto>
{
    private readonly IRepositorioPrestamos _repoPrestamos;

    public ListarPrestamosEnPrestamoPorSocio(IRepositorioPrestamos repoPrestamos)
    {
        _repoPrestamos = repoPrestamos;
    }

    public IEnumerable<ListadoPrestamoSocioDto> Execute(int socioId)
    {
        var prestamos = _repoPrestamos.GetPrestamosEnPrestamoPorSocio(socioId);

        return prestamos.Select(p => new ListadoPrestamoSocioDto
        {
            Id = p.Id,
            FechaInicio = p.FechaInicio,
            FechaFin = p.FechaFin,
            Estado = p.Estado.ToString(),
            EstaAtrasado = !p.EstaVigente()
        });
    }
}