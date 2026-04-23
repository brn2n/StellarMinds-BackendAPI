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
        private ICUDelete<AltaEquipoDto> _delete;
        private ICUGetById<Equipo> _get;

        public EquipoController(ICUAlta<AltaEquipoDto> altaEquipo, ICUGetAll<Equipo> listarEquipo, ICUDelete<AltaEquipoDto> deleteEquipo, ICUGetById<Equipo> getEquipoId)
        {
            _alta = altaEquipo;
            _listar = listarEquipo;
            _delete = deleteEquipo;
            _get = getEquipoId;
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

        public IActionResult Delete(int id)
        {
            return View(_get.Execute(id));

        }

        [HttpPost]
        public IActionResult Delete(AltaEquipoDto equipo)
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

        public IActionResult EditarEquipo()//por id
        {
            return View();

        }
    }
}
