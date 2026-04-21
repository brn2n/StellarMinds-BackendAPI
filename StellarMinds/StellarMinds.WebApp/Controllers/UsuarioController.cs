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
        private ICUAlta<AltaSocioDto> _altaSocio;
        private ICUAlta<AltaAdministradorDto> _altaAdministrador;
        private ICUAlta<AltaCoordinadorDto> _altaCoordinador;
        private ICUGetAll<Usuario> _listar;

        public UsuarioController(ICUAlta<AltaSocioDto> altaSocio, ICUAlta<AltaAdministradorDto> altaAdministrador, ICUAlta<AltaCoordinadorDto> altaCoordinador, ICUGetAll<Usuario> listar)
        {
            _altaSocio = altaSocio;
            _altaAdministrador = altaAdministrador;
            _altaCoordinador = altaCoordinador;
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
        public IActionResult Create(AltaUsuarioDto usuario)
        {
            try
            {
                if (usuario.rol == "Socio")
                {
                    _altaSocio.Ejecutar(new AltaSocioDto(usuario.Id,
                                                          usuario.nombre,
                                                          usuario.apellido,
                                                          usuario.telefono,
                                                          usuario.username,
                                                          usuario.password));
                }
                else if (usuario.rol == "Coordinador")
                {
                    _altaCoordinador.Ejecutar(new AltaCoordinadorDto(usuario.Id,
                                                                  usuario.nombre,
                                                                  usuario.apellido,
                                                                  usuario.telefono,
                                                                  usuario.username,
                                                                  usuario.password));
                }
                else
                {
                    _altaAdministrador.Ejecutar(new AltaAdministradorDto(usuario.Id,
                                                                      usuario.nombre,
                                                                      usuario.apellido,
                                                                      usuario.telefono,
                                                                      usuario.username,
                                                                      usuario.password));
                }
                return RedirectToAction("Index");
            }
            catch (NameInvalidException e)
            {
                ViewBag.message = e.Message;
                return View(usuario);
            }
            catch (Exception e)
            {
                ViewBag.message = e.Message;
                return View(usuario);
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
