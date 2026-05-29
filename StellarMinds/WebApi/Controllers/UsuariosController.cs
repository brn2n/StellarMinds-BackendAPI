using Libreria.Infraestuctura.AccesoDatos.Excepciones;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Excepciones.Error;
using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController(ICUGetAll<ListarUsuariosDto> _listar, ICUAlta<AltaUsuarioDto> _alta) : ControllerBase
    {

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var usuarios = _listar.Ejecutar();
                if (!usuarios.Any())
                {
                    return NoContent();
                }
                return Ok(usuarios);
            }
            catch (Exception)
            {
                return StatusCode(500, new ErrorCodigo(500, "Hupp ahora estoy en otra cosa"));
            }
        }

        [HttpPost]
        public IActionResult Create(AltaUsuarioDto obj)
        {
            try
            {
                _alta.Ejecutar(obj);
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
                return StatusCode(500, new ErrorCodigo(500, "Hupp ahora estoy en otra cosa"));
            }
        }

        //Sería un POST? Qué carajos se hace con las sessions? Ahora son solo tokens?
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }
    }
}
