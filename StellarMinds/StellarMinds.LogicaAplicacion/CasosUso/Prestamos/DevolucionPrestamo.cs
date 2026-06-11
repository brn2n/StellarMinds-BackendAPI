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

        public DevolverPrestamo(IRepositorioPrestamos repoPrestamo, IRepositorioAuditoriaPrestamo repoAuditoria)
        {
            _repoPrestamo = repoPrestamo;
            _repoAuditoria = repoAuditoria;
        }

        public int Execute(int id)
        {
            Prestamo prestamo = _repoPrestamo.GetById(id);

            prestamo.Devolver();

            if (prestamo.Telescopio != null)
            {
                prestamo.Telescopio.AumentarDisponibilidad();
            }

            if (prestamo.Montura != null)
            {
                prestamo.Montura.AumentarDisponibilidad();
            }

            if (prestamo.Camara != null)
            {
                prestamo.Camara.AumentarDisponibilidad();
            }

            if (prestamo.Ocular != null)
            {
                prestamo.Ocular.AumentarDisponibilidad();
            }

            _repoPrestamo.Update(id, prestamo);

            _repoAuditoria.Add(new AuditoriaPrestamo(
                "Devolucion Prestamo",
                prestamo.Id,
                2
            ));

            return prestamo.Id;
        }
    }
}