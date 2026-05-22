using Microsoft.AspNetCore.Mvc;

namespace StellarMinds.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
