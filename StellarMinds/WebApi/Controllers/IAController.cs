using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebApi.Models.IA;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IAController : ControllerBase
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
    }
}
