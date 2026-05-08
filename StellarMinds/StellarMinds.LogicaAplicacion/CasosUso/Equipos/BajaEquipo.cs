using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class BajaEquipo : ICUDelete<AltaEquipoDto>
    {
        private IRepositorioEquipo _repoEquipo;
        private IRepositorioPrestamos _repoPrestamos;

        public BajaEquipo(IRepositorioEquipo repoEquipo, IRepositorioPrestamos repoPrestamos)
        {
            _repoEquipo = repoEquipo;
            _repoPrestamos = repoPrestamos;
        }
        public void Execute(int id)
        {
            if (_repoPrestamos.EnPrestamo(id))
            {
                throw new Exception("El equipo está en préstamo y no puede ser dado de baja.");
            }
            _repoEquipo.Delete(id);
        }
    }
}
