using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.LogicaAplicacion.CasosUso.PrestamoCU
{
    public class DevolverPrestamo : ICUDevolverPrestamo
    {
        private readonly IRepositorioPrestamos _repoPrestamo;
        private readonly IRepositorioAuditoriaPrestamo _repoAuditoria;

        public DevolverPrestamo(
            IRepositorioPrestamos repoPrestamo,
            IRepositorioAuditoriaPrestamo repoAuditoria)
        {
            _repoPrestamo = repoPrestamo;
            _repoAuditoria = repoAuditoria;
        }

        public void Execute(int id, int coordinadorId)
        {
            Prestamo prestamo = _repoPrestamo.GetById(id);

            prestamo.Telescopio?.AumentarDisponibilidad();
            prestamo.Montura?.AumentarDisponibilidad();
            prestamo.Camara?.AumentarDisponibilidad();
            prestamo.Ocular?.AumentarDisponibilidad();
            prestamo.Devolver();

            _repoPrestamo.Update(id, prestamo);

            _repoAuditoria.Add(new AuditoriaPrestamo(
                "Se reporta Devolucion Prestamo",
                prestamo.Id,
                coordinadorId
            ));
        }
    }
}