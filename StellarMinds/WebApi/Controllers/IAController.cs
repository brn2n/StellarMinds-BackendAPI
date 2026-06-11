using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.LogicaAplicacion.CasosUso.IA;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.Dtos.ObjetosCelestes;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IAController(
        ICUGetAll<ListarObjetoCelesteDto> _listarObjetos,
        ICUPrestamosVigentes<ListadoPrestamoSocioDto> _listarPrestamos,
        ICUGetById<ListarObjetoCelesteDto> _getObjeto,
        ICUGetById<ListadoPrestamoSocioDto> _getPrestamo,
        ICUGetById<ListarEquipoDto> _getEquipo
    ) : ControllerBase
    {
        [Authorize(Roles = "Socio")]
        [HttpPost("evaluarObservacion")]
        public async Task<IActionResult> EvaluarObservacion([FromBody] EvaluarObservacionDto dto)
        {
            try
            {
                var prestamo = _getPrestamo.Execute(dto.PrestamoId);
                var objeto = _getObjeto.Execute(dto.ObjetoCelesteId);

                var telescopio = _getEquipo.Execute(prestamo.TelescopioId);
                var camara = prestamo.CamaraId != null ? _getEquipo.Execute(prestamo.CamaraId.Value) : null;
                var montura = prestamo.MonturaId != null ? _getEquipo.Execute(prestamo.MonturaId.Value) : null;
                var ocular = prestamo.OcularId != null ? _getEquipo.Execute(prestamo.OcularId.Value) : null;

                using var client = new HttpClient();

                var prompt = $@"
Evaluá si el siguiente equipo astronómico es adecuado para observar el objeto celeste indicado.

Telescopio:
Marca: {telescopio.Marca}
Modelo: {telescopio.Modelo}
Apertura: {telescopio.Apertura} mm
Distancia focal: {telescopio.DistanciaFocal} mm
Relación focal: {telescopio.RelacionFocal}
Peso: {telescopio.Peso}

Cámara:
Sensor: {camara?.TipoSensorCamara}
Resolución: {camara?.Resolucion}
Tamaño pixel: {camara?.TamanioPixel}

Montura:
Tipo: {montura?.TipoMontura}
Carga soportada: {montura?.CargaUtilSoportada}
Computarizada: {montura?.Computarizada}

Ocular:
Diámetro: {ocular?.Diametro}
Ángulo de visión: {ocular?.AnguloVision}

Objeto celeste:
Nombre: {objeto.Nombre}
Tipo: {objeto.Tipo}

Fecha observación:
{dto.FechaObservacion:yyyy-MM-dd}

Respondé exclusivamente un JSON válido con este formato:
{{
  ""indicador"": ""IDEAL"",
  ""detalle"": ""motivo breve""
}}

El valor de indicador debe ser exactamente uno de estos:
IDEAL, ADECUADO, NO RECOMENDABLE.

No uses markdown.
No agregues texto fuera del JSON.
";

                var body = new
                {
                    model = "llama-3.1-8b-instant",
                    messages = new[]
                    {
                        new
                        {
                            role = "system",
                            content = "Respondé exclusivamente JSON válido. No uses markdown. No agregues texto fuera del JSON."
                        },
                        new
                        {
                            role = "user",
                            content = prompt
                        }
                    },
                    temperature = 0.2
                };

                var request = new HttpRequestMessage(
                    HttpMethod.Post,
                    "https://api.groq.com/openai/v1/chat/completions"
                );

                request.Headers.Add("Authorization", "Bearer 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");

                request.Content = new StringContent(
                    JsonSerializer.Serialize(body),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    var errorGroq = await response.Content.ReadAsStringAsync();

                    return StatusCode((int)response.StatusCode, new
                    {
                        mensaje = "No se pudo evaluar la observación.",
                        detalle = errorGroq
                    });
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(jsonResponse);

                var contenido = doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();

                var resultado = JsonSerializer.Deserialize<ResultadoEvaluacionDto>(
                    contenido!,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );

                return Ok(resultado);
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

        [Authorize(Roles = "Socio")]
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
        [Authorize(Roles = "Socio")]
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