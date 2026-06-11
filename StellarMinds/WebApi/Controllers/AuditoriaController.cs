using Microsoft.AspNetCore.Mvc;
using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.LogicaAplicacion.Dtos.Prestamos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Excepciones.Error;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuditoriaController(ICUListarAuditoriaPrestamos<InfoAuditoriaPrestamosDto> _listarAuditorias,
        ICUDetalleAuditoriaPrestamo<InfoAuditoriaPrestamosDto> _detalleAuditoria) : ControllerBase
    {
        [HttpGet("Auditoria/{coordinadorId}")]
        public IActionResult ListarAuditoriaPrestamos(int coordinadorId)
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

