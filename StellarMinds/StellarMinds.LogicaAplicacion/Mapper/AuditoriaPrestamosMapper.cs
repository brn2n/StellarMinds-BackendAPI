using StellarMinds.LogicaAplicacion.Dtos.Prestamos;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.LogicaAplicacion.Mapper
{
    public class AuditoriaPrestamosMapper
    {
        public static InfoAuditoriaPrestamosDto toDto(AuditoriaPrestamo objeto)
        {
            if (objeto == null) throw new ArgumentNullException(nameof(objeto));

            return new InfoAuditoriaPrestamosDto(objeto.Prestamo.Socio.Username.Value, objeto.Accion, objeto.Fecha);
        }

        public static IEnumerable<InfoAuditoriaPrestamosDto> ToListDto(IEnumerable<AuditoriaPrestamo> prestamos)
        {
            List<InfoAuditoriaPrestamosDto> aux = new List<InfoAuditoriaPrestamosDto>();
            foreach (AuditoriaPrestamo item in prestamos)
            {
                aux.Add(toDto(item));
            }
            return aux;
        }
    }
}
