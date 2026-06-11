using StellarMinds.Infraestructura.InterfacesRepositorio.NochesObservaciones;
using StellarMinds.Infraestructura.InterfacesRepositorio.ObjetosCelestes;
using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.NochesObservaciones;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.NochesObservaciones;
using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.LogicaAplicacion.CasosUso.NochesObservaciones
{
    public class AltaObservacion : ICUAltaObservacion<AltaObservacionDto>
    {
        private readonly IRepositorioNochesObservaciones _repoObservaciones;
        private readonly IRepositorioPrestamos _repoPrestamos;
        private readonly IRepositorioObjetosCelestes _repoObjetos;

        public AltaObservacion(
            IRepositorioNochesObservaciones repoObservaciones,
            IRepositorioPrestamos repoPrestamos,
            IRepositorioObjetosCelestes repoObjetos)
        {
            _repoObservaciones = repoObservaciones;
            _repoPrestamos = repoPrestamos;
            _repoObjetos = repoObjetos;
        }

        public int Ejecutar(AltaObservacionDto dto, int socioId)
        {
            Prestamo prestamo = _repoPrestamos.GetById(dto.PrestamoId);

            if (prestamo == null)
                throw new Exception("No existe el préstamo seleccionado.");

            if (prestamo.SocioId != socioId)
                throw new Exception("El préstamo no pertenece al socio logueado.");

            if (prestamo.Estado != Estado.EN_PRESTAMO)
                throw new Exception("El préstamo no está vigente.");

            ObjetoCeleste objeto = _repoObjetos.GetById(dto.ObjetoCelesteId);

            if (objeto == null)
                throw new Exception("No existe el objeto celeste seleccionado.");

            if (dto.FechaObservacion < DateTime.Today)
                throw new Exception("La fecha de observación no puede ser anterior a hoy.");

            NocheObservacion observacion = new NocheObservacion(
                dto.FechaObservacion,
                prestamo,
                objeto
            );

            return _repoObservaciones.Add(observacion);
        }
    }
}