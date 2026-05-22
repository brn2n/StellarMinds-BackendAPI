using Microsoft.AspNetCore.Mvc;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.WebApp.Filter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StellarMinds.WebApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private ICUGetAll<ListarEquipoDto> _listar;
        private ICUAlta<AltaEquipoDto> _alta;
        private ICUDelete<AltaEquipoDto> _delete;
        private ICUGetById<ListarEquipoDto> _get;
        private ICUEdit<ListarEquipoDto> _update;

        public EquipoController(ICUAlta<AltaEquipoDto> altaEquipo, ICUGetAll<ListarEquipoDto> listarEquipo, ICUDelete<AltaEquipoDto> deleteEquipo, ICUGetById<ListarEquipoDto> getEquipoId, ICUEdit<ListarEquipoDto> updateEquipo)
        {
            _alta = altaEquipo;
            _listar = listarEquipo;
            _delete = deleteEquipo;
            _get = getEquipoId;
            _update = updateEquipo;
        }

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
                return StatusCode(500, new Error(500, "Hupp ahora estoy en otra cosa"));
            }
        }
        public IActionResult AltaEquipo()
        {
            return View();
        }


        [Logueado]
        [Admin]
        [HttpPost]
        public IActionResult AltaEquipo(AltaEquipoDto equipo)
        {
            try
            {
                _alta.Ejecutar(equipo);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            return View(_get.Execute(id));

        }

        [HttpPost]
        public IActionResult Delete(ListarEquipoDto equipo)
        {
            try
            {
                _delete.Execute(equipo.Id);
                return RedirectToAction("index");
            }
            catch (Exception)
            {
                return RedirectToAction("index");
            }
        }

        public IActionResult Edit(int id)
        {
            return View(_get.Execute(id));
        }

        [HttpPost]
        public IActionResult Edit(ListarEquipoDto equipo)
        {
            try
            {
                _update.Execute(equipo.Id, equipo);
                return RedirectToAction("index");
            }
            catch (Exception)
            {

                return RedirectToAction("index");
            }

        }
    }
}