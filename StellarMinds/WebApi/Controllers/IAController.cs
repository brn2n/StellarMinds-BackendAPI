using Microsoft.AspNetCore.Mvc;
using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.LogicaAplicacion.Dtos.ObjetosCelestes;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using WebApi.Models.IA;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IAController(ICUGetAll<ListarObjetoCelesteDto> _listarObjetos, ICUPrestamosVigentes<ListadoPrestamoSocioDto> _listarPrestamos) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using var client = new HttpClient();

            var body = RequestIA.Crear(
                "Quiero saber los nombres de los departamentos de Uruguay. " +
                "Devolveme exclusivamente un JSON válido. " +
                "No agregues explicaciones. " +
                "No utilices markdown."
            );

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent"
            );

            request.Headers.Add("X-goog-api-key", "AQ.Ab8RN6I8Ht5ltENTUhkRzdTpbH2bsn2VZ3diTuPFM5kiNKrHWg");

            request.Content = new StringContent(
                JsonSerializer.Serialize(body),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var jsonResponse =
                await response.Content.ReadAsStringAsync();

            var departamentos =
                ResponseIA.Parsear<List<string>>(jsonResponse);

            return Ok(departamentos);
        }

        [HttpGet("objetosCelestes")]
        public IActionResult ListadoObjetos()
        {
            try
            {
                var objetos = _listarObjetos.Ejecutar();

                if (!objetos.Any())
                    return NoContent();

                return Ok(objetos);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    mensaje = e.Message,
                    inner = e.InnerException?.Message,
                    stack = e.StackTrace
                });
            }
        }

        [HttpGet("prestamosvigentes")]
        public IActionResult PrestamosVigentes()
        {
            try
            {
                var claim = User.FindFirst(ClaimTypes.Sid);

                if (claim == null)
                    return Unauthorized();

                int socioId = int.Parse(claim.Value);

                var prestamos = _listarPrestamos.Execute(socioId);

                if (!prestamos.Any())
                    return NoContent();

                return Ok(prestamos);
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, e.Error());
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    mensaje = e.Message,
                    inner = e.InnerException?.Message
                });
            }
        }

    }
}
