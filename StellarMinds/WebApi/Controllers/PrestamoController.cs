using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace WebApp.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly ICUAlta<AltaPrestamoDto> _altaPrestamo;
        private readonly IRepositorioEquipo _repoEquipo;

        public PrestamoController(
            ICUAlta<AltaPrestamoDto> altaPrestamo,
            IRepositorioEquipo repoEquipo)
        {
            _altaPrestamo = altaPrestamo;
            _repoEquipo = repoEquipo;
        }
    }
}