using Microsoft.AspNetCore.Mvc;

namespace StellarMinds.WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string password)
        {
            if (usuario == "luchosan" && password == "123")
            {
                HttpContext.Session.SetString("Usuario", usuario);
                HttpContext.Session.SetString("Rol", "Administrador");

                return RedirectToAction("Index", "Home");
            }

            if (usuario == "colo" && password == "123")
            {
                HttpContext.Session.SetString("Usuario", usuario);
                HttpContext.Session.SetString("Rol", "Socio");

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}
