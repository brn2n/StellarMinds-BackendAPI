using StellarMinds.LogicaAplicacion.Dtos.Prestamos;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.LogicaAplicacion.Mapper
{
    public class AuditoriaPrestamosMapper
    {
        public static InfoAuditoriaPrestamosDto ToDto(AuditoriaPrestamo auditoria)
        {
            if (auditoria == null)
                throw new ArgumentNullException(nameof(auditoria));

            return new InfoAuditoriaPrestamosDto(
                auditoria.Id,
                auditoria.PrestamoId,
                auditoria.CoordinadorId,
                auditoria.CoordinadorId.ToString(),
                auditoria.Accion,
                auditoria.Fecha
            );
        }

        public static IEnumerable<InfoAuditoriaPrestamosDto> ToListDto(IEnumerable<AuditoriaPrestamo> auditorias)
        {
            return auditorias.Select(ToDto).ToList();
        }
    }
}
