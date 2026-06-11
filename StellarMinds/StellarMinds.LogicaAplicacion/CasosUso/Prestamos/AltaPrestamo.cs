using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaAplicacion.CUExceptions.CUEquipo;
using StellarMinds.LogicaAplicacion.CUExceptions.CUPrestamo;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Equipos;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;

namespace StellarMinds.LogicaAplicacion.CasosUso.PrestamoCU
{
    public class AltaPrestamo : ICUAlta<AltaPrestamoDto>
    {
        private readonly IRepositorioPrestamos _repoPrestamo;
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioUsuario _repoUsuario;
        private readonly IRepositorioAuditoriaPrestamo _repoAuditoria;

        public AltaPrestamo(
            IRepositorioPrestamos repoPrestamo,
            IRepositorioEquipo repoEquipo,
            IRepositorioUsuario repoUsuario,
            IRepositorioAuditoriaPrestamo repoAuditoria)
        {
            _repoPrestamo = repoPrestamo;
            _repoEquipo = repoEquipo;
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }

        public int Ejecutar(AltaPrestamoDto dto)
        {
            if (dto == null)
                throw new PrestamoNuloException();

            Usuario usuario = _repoUsuario.GetById(dto.SocioId);

            if (usuario == null)
                throw new NotFoundException("No existe el usuario seleccionado.");//Excepcion personalizada siempre (por ej badrequest)

            if (usuario is not Socio socio)
                throw new BadRequestException("El usuario seleccionado no es un socio.");

            Telescopio? telescopio = ObtenerTelescopioDisponible(dto.TelescopioId);
            Montura? montura = ObtenerMonturaDisponible(dto.MonturaId);
            Camara? camara = ObtenerCamaraDisponible(dto.CamaraId);
            Ocular? ocular = ObtenerOcularDisponible(dto.OcularId);

            Prestamo prestamo = new Prestamo(
                dto.FechaFin,
                socio,
                montura,
                ocular,
                telescopio,
                camara,
                Estado.EN_PRESTAMO
            );

            _repoPrestamo.Add(prestamo);

            if (telescopio != null)
            {
                telescopio.DescontarDisponibilidad();
                _repoEquipo.Update(telescopio.Id, telescopio);
            }

            if (montura != null)
            {
                montura.DescontarDisponibilidad();
                _repoEquipo.Update(montura.Id, montura);
            }

            if (camara != null)
            {
                camara.DescontarDisponibilidad();
                _repoEquipo.Update(camara.Id, camara);
            }

            if (ocular != null)
            {
                ocular.DescontarDisponibilidad();
                _repoEquipo.Update(ocular.Id, ocular);
            }
            _repoAuditoria.Add(new AuditoriaPrestamo(
                "Alta Prestamo",
                prestamo.Id,
                dto.CoordinadorId
            ));

            return prestamo.Id;
        }

        private Telescopio? ObtenerTelescopioDisponible(int? id)
        {
            if (id == null)
                return null;

            Equipo equipo = _repoEquipo.GetById(id.Value);

            if (equipo is not Telescopio telescopio)
                throw new equipoNoTelescopioException();

            ValidarDisponible(telescopio);

            return telescopio;
        }

        private Montura? ObtenerMonturaDisponible(int? id)
        {
            if (id == null)
                return null;

            Equipo equipo = _repoEquipo.GetById(id.Value);

            if (equipo is not Montura montura)
                throw new equipoNoMonturaException();

            ValidarDisponible(montura);

            return montura;
        }

        private Camara? ObtenerCamaraDisponible(int? id)
        {
            if (id == null)
                return null;

            Equipo equipo = _repoEquipo.GetById(id.Value);

            if (equipo is not Camara camara)
                throw new equipoNoCamaraException();

            ValidarDisponible(camara);

            return camara;
        }

        private Ocular? ObtenerOcularDisponible(int? id)
        {
            if (id == null)
                return null;

            Equipo equipo = _repoEquipo.GetById(id.Value);

            if (equipo is not Ocular ocular)
                throw new equipoNoOcularException();

            ValidarDisponible(ocular);

            return ocular;
        }

        private void ValidarDisponible(Equipo equipo)
        {
            if (equipo.CantDisponible <= 0)
            {
                throw new ConflictException(
                    $"El equipo {equipo.Marca} {equipo.Modelo} no tiene unidades disponibles."
                );
            }
        }
    }
}