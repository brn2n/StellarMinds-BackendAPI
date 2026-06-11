using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;

namespace StellarMinds.LogicaAplicacion.CasosUso.IA
{
    public class GetPrestamoByIdSocioDto : ICUGetById<ListadoPrestamoSocioDto>
    {
        private readonly IRepositorioPrestamos _repo;

        public GetPrestamoByIdSocioDto(IRepositorioPrestamos repo)
        {
            _repo = repo;
        }

        public ListadoPrestamoSocioDto Execute(int id)
        {
            var prestamo = _repo.GetById(id);

            if (prestamo == null)
                throw new NotFoundException("Préstamo no encontrado.");

            return PrestamoMapper.ToDto(prestamo);
        }
    }
}
