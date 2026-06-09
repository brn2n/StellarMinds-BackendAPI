using Libreria.Infraestuctura.AccesoDatos.Excepciones;
using Microsoft.AspNetCore.Mvc;
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
        ICUDelete<AltaPrestamoDto> _devolverPrestamo,
        ICUPrestamosSociosEntreFechas<ListadoPrestamoSocioDto> _listarEntreFechas,
        ICUGetAll<ListadoPrestamoSocioDto> _listarPrestamos
    ) : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var prestamos = _listarPrestamos.Ejecutar();

                if (!prestamos.Any())
                    return NoContent();

                return Ok(prestamos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorCodigo(500, ex.Message));
            }
        }

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
            catch (Exception e)
            {
                return StatusCode(500, new ErrorCodigo(500, e.Message));
            }
        }

        [HttpPut("{id}/devolver")]
        public IActionResult Devolver(int id)
        {
            try
            {
                _devolverPrestamo.Execute(id);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, e.Error());
            }
            catch (ConflictException e)
            {
                return StatusCode(409, e.Error());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorCodigo(500, ex.Message));
            }
        }

        [HttpGet("socio/{socioId}/mes/{mes}/anio/{anio}")]
        public IActionResult ListarEntreFechas(int socioId, int mes, int anio)
        {
            try
            {
                var prestamos = _listarEntreFechas.Ejecutar(socioId, mes, anio);

                if (!prestamos.Any())
                    return NoContent();

                return Ok(prestamos);
            }
            catch (BadRequestException e)
            {
                return StatusCode(400, e.Error());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorCodigo(500, ex.Message));
            }
        }
    }
}