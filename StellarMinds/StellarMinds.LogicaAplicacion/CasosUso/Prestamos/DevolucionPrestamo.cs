using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.LogicaAplicacion.CasosUso.PrestamoCU
{
    public class DevolverPrestamo : ICUDelete<AltaPrestamoDto>
    {
        private readonly IRepositorioPrestamos _repoPrestamo;
        private readonly IRepositorioAuditoriaPrestamo _repoAuditoria;

        public DevolverPrestamo(IRepositorioPrestamos repoPrestamo)
        {
            _repoPrestamo = repoPrestamo;
        }

        public void Execute(int id)
        {
            Prestamo prestamo = _repoPrestamo.GetById(id);

            prestamo.Devolver();

            _repoPrestamo.Update(id, prestamo);
            _repoAuditoria.Add(new AuditoriaPrestamo(
                "Devolucion Prestamo",
                prestamo.Id
                ));
        }
    }
}