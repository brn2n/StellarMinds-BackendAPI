using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.LogicaAplicacion.Dtos.ObjetosCelestes;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ObjetosCelestesController(
        ICUGetAll<RankingObjetosPorSocioDto> _rankingObjetos
    ) : ControllerBase
    {
        [Authorize(Roles = "Administrador,Coordinador,Socio")]
        [HttpGet("ranking")]
        public IActionResult Ranking()
        {
            try
            {
                var ranking = _rankingObjetos.Ejecutar();

                if (!ranking.Any())
                    return NoContent();

                return Ok(ranking);
            }
            catch (BadRequestException e)
            {
                return StatusCode(400, e.Error());
            }
            catch (LogicaNegocioExcepcion e)
            {
                return StatusCode(400, e.Error());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, new
                {
                    mensaje = e.Message,
                    inner = e.InnerException?.Message,
                    stack = e.StackTrace
                });
            }
        }
    }
}