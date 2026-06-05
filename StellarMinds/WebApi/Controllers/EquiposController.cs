using Libreria.Infraestuctura.AccesoDatos.Excepciones;
using Microsoft.AspNetCore.Mvc;
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
        private ICUEdit<ListarEquipoDto> _update;

        public EquiposController(ICUAlta<AltaEquipoDto> altaEquipo, ICUGetAll<ListarEquipoDto> listarEquipo, ICUDelete<AltaEquipoDto> deleteEquipo, ICUGetById<ListarEquipoDto> getEquipoId, ICUEdit<ListarEquipoDto> updateEquipo)
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
                return StatusCode(500, new ErrorCodigo(500, "Hupp ahora estoy en otra cosa"));
            }
        }


        // PONERLE QUE EL REPOSITORIO DEVUEVLA ID EN EL CREATE !!!!!!!!!!!!!!!!!!!!! TODO NECESITA IID AHORA

        [HttpPost]
        public IActionResult AltaEquipo([FromBody] AltaEquipoDto equipo)
        {
            try
            {
                _alta.Ejecutar(equipo);
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


        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _delete.Execute(Id);
                return Ok();
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

        // PONERLE QUE EL REPOSITORIO DEVUEVLA ID EN EL EDIT !!!!!!!!!!!!!!!!!!!!! TODO NECESITA IID AHORA
        [HttpPut("{id}")]
        public IActionResult Edit(int Id, [FromBody] ListarEquipoDto equipo)
        {
            try
            {
                _update.Execute(Id, equipo);
                return RedirectToAction("index");
            }
            catch (Exception)
            {

                return RedirectToAction("index");
            }

        }
    }
}