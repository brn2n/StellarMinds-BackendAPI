using Microsoft.AspNetCore.Mvc;
using StellarMinds.LogicaAplicacion.Dtos.ObjetosCelestes;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Excepciones.Error;

namespace WebApi.Controllers
{
    public class ObjetosCelestesController(ICUGetAll<RankingObjetosPorSocioDto> _getObjetos) : Controller
    {
        [HttpPost]
        public ActionResult Index()
        {

            try
            {
                var paises = _getObjetos.Ejecutar();
                if (!paises.Any())
                {
                    return NoContent();
                }
                return Ok(paises);
            }
            catch (Exception)
            {
                return StatusCode(500, new ErrorCodigo(500, "No hay objetos para mostrarse"));
            }
        }
    }
}
