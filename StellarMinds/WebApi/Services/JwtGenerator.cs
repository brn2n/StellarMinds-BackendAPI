using Microsoft.IdentityModel.Tokens;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Libreria.WepApi.Services
{
    public class JwtGenerator : IJwtGenerator<JWTUsuarioDto>
    {

        private readonly JwtSettings _settings;

        public JwtGenerator(JwtSettings settings)
        {
            _settings = settings;
        }

        public string GenerateToken(JWTUsuarioDto usuario)
        {
            var key = Encoding.UTF8.GetBytes(_settings.Key);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.PreferredUsername, usuario.username),
                new Claim(ClaimTypes.Role, usuario.rol),
                new Claim(ClaimTypes.Sid, usuario.Id.ToString())
                // Podés agregar más claims como rol, nombre, etc.
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
