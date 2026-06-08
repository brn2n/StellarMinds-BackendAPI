using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.LogicaAplicacion.Dtos.NochesObservaciones;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Excepciones.Error;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NochesObservacionesController(ICUAlta<AltaObservacionDto> _altaObservacion) : ControllerBase
    {
        [HttpPost]
        public IActionResult Alta([FromBody] AltaObservacionDto dto)
        {
            try
            {
                int id = _altaObservacion.Ejecutar(dto);

                return Ok(new
                {
                    mensaje = "Noche de observación creada correctamente.",
                    id
                });

            }
            catch (Exception e)
            {

                return StatusCode(400, new ErrorCodigo(400, e.Message));
            }
        }
    }
}
