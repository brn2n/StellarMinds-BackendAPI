using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Excepciones.Error;
using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace StellarMinds.WebApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly ICUGetAll<ListarEquipoDto> _listar;
        private readonly ICUAlta<AltaEquipoDto> _alta;
        private readonly ICUDelete<AltaEquipoDto> _delete;
        private readonly ICUEdit<AltaEquipoDto> _update;
        private readonly ICUGetById<ListarEquipoDto> _get;

        public EquiposController(
            ICUAlta<AltaEquipoDto> altaEquipo,
            ICUGetAll<ListarEquipoDto> listarEquipo,
            ICUDelete<AltaEquipoDto> deleteEquipo,
            ICUEdit<AltaEquipoDto> updateEquipo,
            ICUGetById<ListarEquipoDto> get)
        {
            _alta = altaEquipo;
            _listar = listarEquipo;
            _delete = deleteEquipo;
            _update = updateEquipo;
            _get = get;
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var equipos = _listar.Ejecutar();

                if (!equipos.Any())
                    return NoContent();

                return Ok(equipos);
            }
            catch (Exception)
            {
                return StatusCode(500, new ErrorCodigo(500, "Hupp ahora estoy en otra cosa"));
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
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult AltaEquipo([FromBody] AltaEquipoDto equipo)
        {
            try
            {
                int id = _alta.Ejecutar(equipo);
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
            catch (Exception)
            {
                return StatusCode(500, new ErrorCodigo(500, "Hupp ahora estoy en otra cosa"));
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //_delete.Execute(Id);
                //return Ok(Id);
                int idEliminado = _delete.Execute(id);
                return Ok(idEliminado);
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, e.Error());
            }
            catch (ConflictException e)
            {
                return StatusCode(409, e.Error());
            }
            catch (Exception)
            {
                return StatusCode(500, new ErrorCodigo(500, "Hupp ahora estoy en otra cosa"));
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] AltaEquipoDto equipo)
        {
            try
            {
                _update.Execute(id, equipo);
                return Ok(id);
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, e.Error());
            }
            catch (ConflictException e)
            {
                return StatusCode(409, e.Error());
            }
            catch (LogicaNegocioExcepcion e)
            {
                return StatusCode(409, e.Error());
            }
            catch (Exception)
            {
                return StatusCode(500, new ErrorCodigo(500, "Hupp ahora estoy en otra cosa"));
            }
        }
    }
}