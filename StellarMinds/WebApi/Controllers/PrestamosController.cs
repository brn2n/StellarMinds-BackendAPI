using Libreria.Infraestuctura.AccesoDatos.Excepciones;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.Dtos.Prestamos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using StellarMinds.LogicaNegocio.Excepciones.Error;
using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PrestamosController(
        ICUAltaPrestamo _altaPrestamo,
        ICUListarPrestamosEnPrestamoPorSocio<ListadoPrestamoSocioDto> _listarPrestamosActivosSocio,
        ICUPrestamosSociosEntreFechas<ListadoPrestamoSocioDto> _listarPrestamosSocioEntreFechas,
        ICUDevolverPrestamo _devolverPrestamo,
        ICUListarAuditoriaPrestamos<InfoAuditoriaPrestamosDto> _listarAuditorias,
        ICUDetalleAuditoriaPrestamo<InfoAuditoriaPrestamosDto> _detalleAuditoria
    ) : ControllerBase
    {
        [HttpPost]
        public IActionResult Alta([FromBody] AltaPrestamoDto dto)
        {
            try
            {
                int coordinadorId = 2; // TEMPORAL: después lo sacamos del JWT

                _altaPrestamo.Ejecutar(dto, coordinadorId);
                return Ok();
            }
            catch (BadRequestException e)
            {
                return StatusCode(400, e.Error());
            }
            catch (LogicaNegocioExcepcion e)
            {
                return StatusCode(400, e.Error());
            }
            catch (Exception)
            {
                return StatusCode(500, new ErrorCodigo(500, "Hupp ahora estoy en otra cosa"));
            }
        }

        [HttpGet("Socio/{socioId}/EnPrestamo")]
        public IActionResult ListarPrestamosEnPrestamoPorSocio(int socioId)
        {
            try
            {
                var prestamos = _listarPrestamosActivosSocio.Execute(socioId);

                if (!prestamos.Any())
                    return NoContent();

                return Ok(prestamos);
            }
            catch (BadRequestException e)
            {
                return StatusCode(400, e.Error());
            }
            catch (Exception)
            {
                return StatusCode(500, new ErrorCodigo(500, "Hupp ahora estoy en otra cosa"));
            }
        }

        [HttpGet("Socio/{socioId}/EntreFechas")]
        public IActionResult ListarPrestamosSocioEntreFechas(
            int socioId,
            [FromQuery] int mes,
            [FromQuery] int anio)
        {
            try
            {
                var prestamos = _listarPrestamosSocioEntreFechas.Ejecutar(socioId, mes, anio);

                if (!prestamos.Any())
                    return NoContent();

                return Ok(prestamos);
            }
            catch (BadRequestException e)
            {
                return StatusCode(400, e.Error());
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new ErrorCodigo(400, e.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, new ErrorCodigo(500, "Hupp ahora estoy en otra cosa"));
            }
        }

        [HttpPut("Devolver/{prestamoId}")]
        public IActionResult DevolverPrestamo(int prestamoId)
        {
            try
            {
                int coordinadorId = 2; // TEMPORAL: después lo sacamos del JWT

                _devolverPrestamo.Execute(prestamoId, coordinadorId);

                return Ok("Préstamo devuelto correctamente.");
            }
            catch (BadRequestException e)
            {
                return StatusCode(400, e.Error());
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, e.Error());
            }
            catch (LogicaNegocioExcepcion e)
            {
                return StatusCode(400, e.Error());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }

        [HttpGet("Auditoria")]
        public IActionResult ListarAuditoriaPrestamos([FromQuery] int? coordinadorId)
        {
            try
            {
                var auditorias = _listarAuditorias.Ejecutar(coordinadorId);

                if (!auditorias.Any())
                    return NoContent();

                return Ok(auditorias);
            }
            catch (BadRequestException e)
            {
                return StatusCode(400, e.Error());
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorCodigo(500, e.Message));
            }
        }

        [HttpGet("{prestamoId}/Auditoria")]
        public IActionResult VerAuditoriaPrestamo(int prestamoId)
        {
            try
            {
                var auditorias = _detalleAuditoria.Ejecutar(prestamoId);

                if (!auditorias.Any())
                    return NoContent();

                return Ok(auditorias);
            }
            catch (BadRequestException e)
            {
                return StatusCode(400, e.Error());
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorCodigo(500, e.Message));
            }
        }
    }
}