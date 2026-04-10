 using Microsoft.AspNetCore.Mvc;

namespace StellarMinds.WebApp.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
