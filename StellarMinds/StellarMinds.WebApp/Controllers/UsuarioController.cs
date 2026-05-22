using Microsoft.AspNetCore.Mvc;
using StellarMinds.WebApp.Filter;

namespace StellarMinds.WebApp.Controllers
{
    public class UsuarioController : Controller
    {


        [Logueado]
        public IActionResult Index()
        {
            return View(_listar.Ejecutar());
        }

        [Logueado]
        [Admin]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AltaUsuarioDto obj)
        {
            try
            {
                _alta.Ejecutar(obj);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.message = e.Message;
                return View();
            }
        }

        public IActionResult ListadoSociosPorTelescopio()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }

    }
}
