namespace StellarMinds.LogicaAplicacion.Dtos.Prestamos
{
    public record InfoAuditoriaPrestamosDto(
        int AuditoriaId,
        int PrestamoId,
        int CoordinadorId,
        string Usuario,
        string Accion,
        DateTime Fecha
    );
}
