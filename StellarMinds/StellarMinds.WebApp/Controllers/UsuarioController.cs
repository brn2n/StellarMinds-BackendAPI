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
        private ICUAlta<AltaSocioDto> _alta;
        private ICUGetAll<Usuario> _listar;

        public UsuarioController(ICUAlta<AltaSocioDto> alta, ICUGetAll<Usuario> listar)
        {
            _alta = alta;
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
        public IActionResult Create(AltaSocioDto socio)
        {
            try
            {
                _alta.Ejecutar(new AltaSocioDto(socio.Id,
                                                      socio.nombre,
                                                      socio.apellido,
                                                      socio.telefono,
                                                      socio.username,
                                                      socio.password));
                return RedirectToAction("Index");
            }
            catch (NameInvalidException e)
            {
                ViewBag.message = e.Message;
                return View(socio);
            }
            catch (Exception e)
            {
                ViewBag.message = e.Message;
                return View(socio);
            }
        }



        public IActionResult ListadoSociosPorTelescopio()
        {
            return View();
        }
    }
}
