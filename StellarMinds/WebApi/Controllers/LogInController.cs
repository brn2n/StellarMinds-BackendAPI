using Microsoft.AspNetCore.Mvc;
using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LogInController(ICULogIn<LoginUsuariosDto> _logIn) : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginUsuariosDto login)
        {

            try
            {
                string tokenRecibido = _logIn.Execute(login);
                return Ok(new { token = tokenRecibido });
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
                Console.WriteLine(e.Message);
                return StatusCode(500, new
                {
                    mensaje = e.Message,
                    inner = e.InnerException?.Message,
                    stack = e.StackTrace
                });
            }
        }
        //EL TOKEN LO GUARDO EN UN SESSION EN EL FRONTEND
    }
}
