using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.LogicaAplicacion.Mapper
{
    public class PrestamoMapper
    {
        public static ListadoPrestamoSocioDto ToDto(Prestamo prestamo)
        {
            if (prestamo == null)
                throw new ArgumentNullException(nameof(prestamo));

            return new ListadoPrestamoSocioDto(prestamo.Id, prestamo.SocioId, prestamo.FechaInicio, prestamo.FechaFin, prestamo.Estado.ToString(), prestamo.EstaVigente());
        }

        public static IEnumerable<ListadoPrestamoSocioDto> ToListDto(IEnumerable<Prestamo> prestamo)
        {
            List<ListadoPrestamoSocioDto> aux = new List<ListadoPrestamoSocioDto>();
            foreach (Prestamo item in prestamo)
            {
                aux.Add(ToDto(item));
            }
            return aux;
        }
    }
}

