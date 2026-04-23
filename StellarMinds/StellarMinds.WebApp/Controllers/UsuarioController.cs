using Microsoft.AspNetCore.Mvc;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using StellarMinds.LogicaNegocio.Excepciones.EntidadesException.UsuarioException;
using StellarMinds.WebApp.Filter;

namespace StellarMinds.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private ICUGetAll<Usuario> _listar;
        private ICUAlta<AltaUsuarioDto> _alta;

        public UsuarioController(ICUAlta<AltaUsuarioDto> altaUsuario, ICUGetAll<Usuario> listar)
        {
            _alta = altaUsuario;
            _listar = listar;
        }

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
