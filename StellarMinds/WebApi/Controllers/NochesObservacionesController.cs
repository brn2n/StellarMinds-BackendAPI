using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.LogicaAplicacion.Dtos.NochesObservaciones;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Excepciones.Error;
using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NochesObservacionesController(ICUAlta<AltaObservacionDto> _altaObservacion, ICUGetById<AltaObservacionDto> _get) : ControllerBase
    {
        [Authorize(Roles = "Socio")]
        [HttpPost]
        public IActionResult Alta([FromBody] AltaObservacionDto dto)
        {
            try
            {
                int id = _altaObservacion.Ejecutar(dto);
                return CreatedAtAction(nameof(GetById), new { id = id }, id);

            }
            catch (BadRequestException e)
            {
                return StatusCode(400, e.Error());
            }
            catch (LogicaNegocioExcepcion e)
            {
                return StatusCode(400, e.Error());
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, new { e.Message });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, new
                {
                    mensaje = e.Message,
                    inner = e.InnerException?.Message,
                    stack = e.StackTrace
                });
            }
        }


        [HttpGet("{id}")]
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
