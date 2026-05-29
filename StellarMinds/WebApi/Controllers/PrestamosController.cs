using Microsoft.AspNetCore.Mvc;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PrestamosController(ICUAlta<AltaPrestamoDto> _altaPrestamo) : ControllerBase
    {

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
