using Microsoft.AspNetCore.Mvc;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Equipos;
using StellarMinds.WebApp.Filter;

namespace StellarMinds.WebApp.Controllers
{
    public class EquipoController : Controller
    {
        private ICUGetAll<Equipo> _listar;
        private ICUAlta<AltaEquipoDto> _alta;

        public EquipoController(ICUAlta<AltaEquipoDto> altaEquipo, ICUGetAll<Equipo> listarEquipo)
        {
            _alta = altaEquipo;
            _listar = listarEquipo;
        }

        public IActionResult Index()
        {
            return View(_listar.Ejecutar());
        }
        //ESTO SOLO LO HACEN LOS ADMINISTRADORES
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

        public IActionResult BajaEquipo()//por id
        {
            return View();
        }

        public IActionResult EditarEquipo()//por id
        {
            return View();

        }
    }
}
