using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;

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
                _altaPrestamo.Ejecutar(dto);
                return Ok("Prestamo creado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
