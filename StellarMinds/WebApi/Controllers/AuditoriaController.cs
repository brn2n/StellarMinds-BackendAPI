using Microsoft.AspNetCore.Mvc;
using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.Dtos.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Excepciones.Error;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuditoriaController(ICUListarAuditoriaPrestamos<InfoAuditoriaPrestamosDto> _listarAuditorias,
        ICUGetById<ListadoPrestamoSocioDto> _get,
        ICUGetAllCoordinadores<ListarUsuariosDto> _listarCoordinadores) : ControllerBase
    {
        [HttpGet("{coordinadorId}")]
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
            catch (NotFoundException e)
            {
                return StatusCode(404, e.Error());
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorCodigo(500, e.Message));
            }
        }

        [HttpGet("coordinadores")]
        public IActionResult ListarCoordinadores()
        {
            try
            {
                var auditorias = _listarCoordinadores.Ejecutar();

                if (!auditorias.Any())
                    return NoContent();

                return Ok(auditorias);
            }
            catch (BadRequestException e)
            {
                return StatusCode(400, e.Error());
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, e.Error());
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorCodigo(500, e.Message));
            }
        }



        [HttpGet("prestamo/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_get.Execute(id));
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, new { e.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new ErrorCodigo(500, "Error interno del servidor."));
            }
        }
    }
}

