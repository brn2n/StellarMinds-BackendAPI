using Microsoft.AspNetCore.Mvc;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LogInController(IJwtGenerator<JWTUsuarioDto> _jwtGenerator) : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginUsuariosDto login)
        {
            // Ir a buscar al caso de uso este usuario 
            // Luego veo que instancia de usuario es, si es admin, vendedor o cliente
            //(if user == null)
            // el mensaje de error debe ser credenciales invalidas, nunca decir el username esta mal o password mal

            //if (user.Usuario == "luchosan" && user.Password == "123")
            //{
            //    HttpContext.Session.SetString("Usuario", user.Usuario);
            //    HttpContext.Session.SetString("Rol", "Administrador");

            //    return RedirectToAction("Index", "Home");
            //}

            //if (user.Usuario == "colo" && user.Password == "123")
            //{
            //    HttpContext.Session.SetString("Usuario", user.Usuario);
            //    HttpContext.Session.SetString("Rol", "Socio");

            //    return RedirectToAction("Index", "Home");
            //}
            //return Ok();

            JWTUsuarioDto user = new JWTUsuarioDto(11, login.Usuario, "Socio");

            var token = _jwtGenerator.GenerateToken(user);
            return Ok(new { token });
        }


        // Siempre tengo que limpiar el session para que no quede nada guardado, por ejemplo el rol, porque si no, aunque el usuario se desloguee, el rol queda guardado y puede acceder a secciones que no le corresponden
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}
