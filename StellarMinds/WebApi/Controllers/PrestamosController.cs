using Microsoft.AspNetCore.Mvc;
using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Excepciones.Error;
using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PrestamosController(
        ICUAlta<AltaPrestamoDto> _altaPrestamo,
        ICUListarPrestamosEnPrestamoPorSocio<ListadoPrestamoSocioDto> _listarPrestamosActivosSocio,
        ICUPrestamosSociosEntreFechas<ListadoPrestamoSocioDto> _listarPrestamosSocioEntreFechas,
        ICUDelete<int> _devolverPrestamo
    ) : ControllerBase
    {
        [HttpPost]
        public IActionResult Alta([FromBody] AltaPrestamoDto dto)
        {
            try
            {
                _altaPrestamo.Ejecutar(dto);
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
                _devolverPrestamo.Execute(prestamoId);
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
            catch (Exception)
            {
                return StatusCode(500, new ErrorCodigo(500, "Hupp ahora estoy en otra cosa"));
            }
        }
    }
}