using Microsoft.AspNetCore.Mvc;

namespace StellarMinds.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult ListadoSociosPorTelescopio()
        {
            return View();
        }
    }
}
