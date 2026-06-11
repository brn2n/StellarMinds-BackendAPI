using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Excepciones.Error;
using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController(ICUGetAll<ListarUsuariosDto> _listar, ICUAlta<AltaUsuarioDto> _alta, ICUGetByTelescopio<ListarUsuariosDto> _getByTelescopio, ICUGetById<AltaUsuarioDto> _get) : ControllerBase
    {
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador,Coordinador")]
        [HttpGet("ListadoTelescopio/{id}")]
        public IActionResult ListarSocioPorTelescopio(int id)
        {
            try
            {
                var telescopios = _getByTelescopio.Ejecutar(id);
                if (!telescopios.Any())
                {
                    return NoContent();
                }
                return Ok(telescopios);
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, e.Error());
            }
            catch (BadRequestException e)
            {
                return StatusCode(400, e.Error());
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorCodigo(500, e.Message));
            }
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Create([FromBody] AltaUsuarioDto obj)
        {
            try
            {
                int id = _alta.Ejecutar(obj);
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
            catch (Exception e)
            {
                return StatusCode(500, new ErrorCodigo(500, "Error interno del servidor."));
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
