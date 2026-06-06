using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.LogicaAplicacion.CasosUso.PrestamoCU
{
    public class DevolverPrestamo : ICUDelete<int>
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

        public void Execute(int id)
        {
            Prestamo prestamo = _repoPrestamo.GetById(id);

            prestamo.Devolver();

            _repoPrestamo.Update(id, prestamo);

            _repoAuditoria.Add(
                new AuditoriaPrestamo(
                    "Devolucion Prestamo",
                    prestamo.Id
                )
            );
        }
    }
}