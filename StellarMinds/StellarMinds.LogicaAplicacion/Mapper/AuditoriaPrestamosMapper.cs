using StellarMinds.LogicaAplicacion.Dtos.Prestamos;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.LogicaAplicacion.Mapper
{
    public class AuditoriaPrestamosMapper
    {
        public static InfoAuditoriaPrestamosDto ToDto(AuditoriaPrestamo auditoria)
        {
            if (auditoria == null) throw new ArgumentNullException(nameof(auditoria));

            string coordinadorNombre = "Sin coordinador";

            if (auditoria.Coordinador != null && auditoria.Coordinador.NombreCompleto != null)
            {
                coordinadorNombre = $"{auditoria.Coordinador.NombreCompleto.Nombre} {auditoria.Coordinador.NombreCompleto.Apellido}";
            }

            return new InfoAuditoriaPrestamosDto(
                auditoria.Id,
                auditoria.PrestamoId,
                auditoria.CoordinadorId,
                coordinadorNombre,
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
