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
    public class PrestamosController : ControllerBase
    {
        private ICUAlta<AltaPrestamoDto> _altaPrestamo;

        public PrestamosController(ICUAlta<AltaPrestamoDto> altaPrestamo)
        {
            _altaPrestamo = altaPrestamo;
        }

        [HttpPost]
        public IActionResult Alta([FromBody] AltaPrestamoDto dto)
        {
            try
            {
                //'/int nuevoId =/'
                _altaPrestamo.Ejecutar(dto);
                return Ok(); // "nombre del metodo que recibe en getby, id como int, y el objeto del id new {id}"
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
                return StatusCode(500, new ErrorCodigo(500, "Hupp ahora estoy en otra cosa"));
            }
        }
    }
}
