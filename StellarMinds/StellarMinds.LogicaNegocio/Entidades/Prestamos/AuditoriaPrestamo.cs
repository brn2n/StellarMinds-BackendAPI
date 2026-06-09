namespace StellarMinds.LogicaNegocio.Entidades.Prestamos
{
    public class AuditoriaPrestamo
    {
        public int Id { get; private set; }
        public string Accion { get; private set; }
        public DateTime Fecha { get; private set; }
        public int PrestamoId { get; private set; }
        public int CoordinadorId { get; private set; }
        public Prestamo Prestamo { get; private set; }

        private AuditoriaPrestamo()
        {
        }

        public AuditoriaPrestamo(string accion, int prestamoId, int coordinadorId)
        {
            Accion = accion;
            Fecha = DateTime.Now;
            PrestamoId = prestamoId;
            CoordinadorId = coordinadorId;
        }
    }
}