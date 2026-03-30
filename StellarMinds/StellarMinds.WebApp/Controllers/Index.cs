using Microsoft.AspNetCore.Mvc;

namespace StellarMinds.WebApp.Controllers
{
    public class Index : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
