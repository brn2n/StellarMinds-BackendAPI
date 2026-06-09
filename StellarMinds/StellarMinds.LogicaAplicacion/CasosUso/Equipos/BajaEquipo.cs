using StellarMinds.Infraestructura.EF.Exceptions;
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
        public int Execute(int id)
        {
            if (_repoPrestamos.EnPrestamo(id))
            {
                throw new ConflictException("El equipo está en préstamo y no puede ser dado de baja.");
            }
            if (_repoPrestamos.FueUsadoEnPrestamo(id))
            {
                throw new ConflictException(
                    "El equipo tiene préstamos asociados y no puede ser dado de baja."
                );
            }
            _repoEquipo.Delete(id);

            return id;
        }
    }
}
