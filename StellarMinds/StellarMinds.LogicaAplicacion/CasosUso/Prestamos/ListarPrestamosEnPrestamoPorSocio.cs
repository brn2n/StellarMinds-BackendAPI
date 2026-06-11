using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

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

        return PrestamoMapper.ToListDto(_repoPrestamos.GetPrestamosEnPrestamoPorSocio(socioId));
    }
}