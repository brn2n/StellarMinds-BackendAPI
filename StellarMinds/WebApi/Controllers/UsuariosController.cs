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
        //HASHEAR CONTRASENIA, VALIDAR DATOS DE LOGIN (servicio para generar el token)... caso de uso para CULOGIN TRANSFORMAS A JWT
        //USUARIO DTO CON LOS DATOS QUE ME FALTAN SI ESTA TODO CORRECTO, GUARDAS EN BUSCAR POR USERNAME MATODO, (CREAR REPOGETBYNAME)
        //THROW NEW EXCEPTION SI NO EXISTE USUARIO NI NADA, LUEGO DE VALIDADO, SEGUIS A VALIDAR LA CONTRASE;A CON LA CONTRASE;A YA HASHEADA,
        //SI EL IF DE ESE RESULTADO DA OK SEGUIS CON LO SIGUIENTE, DTOJTWUSERDTO EL USER QUE RECOLECTASTE Y AHI DEVOLVES EL TOKEN, INTERFAZ
        //DEVUELVE UN STRING Y ACEPTA UN T DEL LOGIN.
        //CONTROLLER ENVIA LOGINDTO, CU LO RECIBE, USA GETUSUARIOBYUSERNAME, CON ESTO OBTENGO EL OBJETO PARA VALIDAR LA CONTRASENIA INGRESADA
        //CON LA HASHEADA. RECIEN AHI GENERO EL TOKEN CON EL DTOJTWUSERDTO Y LO RETORNO COMO STRING
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

        [HttpPost("ListadoTelescopio")]
        public IActionResult ListarSocioPorTelescoio(int id)
        {
            try
            {
                var usuarios = _getByTelescopio.Ejecutar(id);
                return Ok(usuarios);
            }
            catch (BadRequestException e)
            {
                return StatusCode(400, e.Error());
            }
        }

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

        //Sería un POST? Qué carajos se hace con las sessions? Ahora son solo tokens?
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }
    }
}
