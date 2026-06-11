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

            return new ListadoPrestamoSocioDto
            {
                Id = prestamo.Id,
                SocioId = prestamo.SocioId,

                TelescopioId = prestamo.TelescopioId,
                CamaraId = prestamo.CamaraId,
                MonturaId = prestamo.MonturaId,
                OcularId = prestamo.OcularId,

                FechaInicio = prestamo.FechaInicio,
                FechaFin = prestamo.FechaFin,

                Estado = prestamo.Estado.ToString(),
                EstaAtrasado = prestamo.EstaVigente()
            };
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

