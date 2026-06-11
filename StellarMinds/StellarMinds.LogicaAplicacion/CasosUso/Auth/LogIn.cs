using StellarMinds.Infraestructura.EF.Exceptions;
using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;

namespace StellarMinds.LogicaAplicacion.CasosUso.Auth
{
    public class LogIn(IRepositorioUsuario _repo, IJwtGenerator<JWTUsuarioDto> _jwtGenerator) : ICULogIn<LoginUsuariosDto>
    {
        public string Execute(LoginUsuariosDto t)
        {
            Usuario usuario = _repo.LogInAuth(t.Usuario, t.Password);
            if (usuario == null)
            {
                throw new BadRequestException("Usuario o contraseña incorrectos.");
            }

            return _jwtGenerator.GenerateToken(UsuarioMapper.toDtoJwt(usuario));
        }

    }
}

