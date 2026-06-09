using Microsoft.AspNetCore.Mvc;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;

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
            catch (Exception)
            {

                throw;
            }
        }
        //EL TOKEN LO GUARDO EN UN SESSION EN EL FRONTEND
    }
}
