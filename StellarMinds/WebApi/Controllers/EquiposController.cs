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
        private ICUGetAll<ListarEquipoDto> _listar;
        private ICUAlta<AltaEquipoDto> _alta;
        private ICUDelete<AltaEquipoDto> _delete;
        private ICUGetById<ListarEquipoDto> _get;
        private ICUEdit<AltaEquipoDto> _update;

        public EquiposController(ICUAlta<AltaEquipoDto> altaEquipo, ICUGetAll<ListarEquipoDto> listarEquipo, ICUDelete<AltaEquipoDto> deleteEquipo, ICUGetById<ListarEquipoDto> getEquipoId, ICUEdit<AltaEquipoDto> updateEquipo)
        {
            _alta = altaEquipo;
            _listar = listarEquipo;
            _delete = deleteEquipo;
            _get = getEquipoId;
            _update = updateEquipo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var paises = _listar.Ejecutar();
                if (!paises.Any())
                {
                    return NoContent();
                }
                return Ok(paises);
            }
            catch (Exception)
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
            catch (Exception e)
            {
                return StatusCode(500, new ErrorCodigo(500, "Error interno del servidor."));
            }
        }




        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _delete.Execute(Id);
                return Ok(Id);
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
                return StatusCode(500, new ErrorCodigo(500, "Error interno del servidor."));
            }
        }


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
                return StatusCode(400, e.Error());
            }
            catch (Exception)
            {
                return StatusCode(500, new ErrorCodigo(500, "Error interno del servidor."));
            }
            //catch (Exception e)
            //{
            //    // Temporalmente para debuggear:
            //    return StatusCode(500, e.Message + " || " + e.StackTrace);
            //}
        }
    }
}