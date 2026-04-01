using Microsoft.AspNetCore.Mvc;

namespace StellarMinds.WebApp.Controllers
{
    public class EquipoController : Controller
    {
        //ESTO SOLO LO HACEN LOS ADMINISTRADORES
        public IActionResult AltaEquipo()
        {
            return View();
        }

        public IActionResult BajaEquipo()
        {
            return View();
        }

        public IActionResult EditarEquipo()
        {
            return View();
        }
    }
}
