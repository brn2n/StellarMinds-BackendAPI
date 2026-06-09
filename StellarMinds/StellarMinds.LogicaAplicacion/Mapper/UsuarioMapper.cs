using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using StellarMinds.LogicaNegocio.VO.VOUsuario;

namespace StellarMinds.LogicaAplicacion.Mapper
{
    public class UsuarioMapper
    {
        public static Usuario FromDto(AltaUsuarioDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var nombreCompleto = new VONombreCompleto(dto.nombre, dto.apellido);
            var telefono = new VOTelefono(dto.telefono);
            var username = new VOUsername(dto.username);
            var password = new VOPassword(dto.password);

            if (dto.rol == "Socio")
                return new Socio(dto.Id, nombreCompleto, telefono, username, password);

            if (dto.rol == "Coordinador")
                return new Coordinador(dto.Id, nombreCompleto, telefono, username, password);

            if (dto.rol == "Administrador")
                return new Administrador(dto.Id, nombreCompleto, telefono, username, password);

            throw new Exception("Rol de usuario inválido");
        }


        public static ListarUsuariosDto toDto(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            if (usuario is Coordinador c)
            {
                return new ListarUsuariosDto(c.NombreCompleto.Nombre, c.NombreCompleto.Apellido, c.Telefono.Value, c.Username.Value, "Coordinador");
            }

            if (usuario is Administrador a)
            {
                return new ListarUsuariosDto(a.NombreCompleto.Nombre, a.NombreCompleto.Apellido, a.Telefono.Value, a.Username.Value, "Administrador");
            }

            if (usuario is Socio s)
            {
                return new ListarUsuariosDto(s.NombreCompleto.Nombre, s.NombreCompleto.Apellido, s.Telefono.Value, s.Username.Value, "Socio");
            }
            throw new ArgumentException("Tipo de equipo desconocido", nameof(usuario));
        }

        public static JWTUsuarioDto toDtoJwt(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            if (usuario is Coordinador c)
            {
                return new JWTUsuarioDto(usuario.Id, usuario.Username.Value, "Coordinador");
            }

            if (usuario is Administrador a)
            {
                return new JWTUsuarioDto(usuario.Id, usuario.Username.Value, "Administrador");
            }

            if (usuario is Socio s)
            {
                return new JWTUsuarioDto(usuario.Id, usuario.Username.Value, "Socio");
            }
            throw new ArgumentException("Tipo de equipo desconocido", nameof(usuario));
        }

        public static AltaUsuarioDto toDtoGet(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            if (usuario is Coordinador c)
            {
                return new AltaUsuarioDto(c.Id, c.NombreCompleto.Nombre, c.NombreCompleto.Apellido, c.Telefono.Value, c.Username.Value, c.VOPassword.Value, "Coordinador");
            }

            if (usuario is Administrador a)
            {
                return new AltaUsuarioDto(a.Id, a.NombreCompleto.Nombre, a.NombreCompleto.Apellido, a.Telefono.Value, a.Username.Value, a.VOPassword.Value, "Administrador");
            }

            if (usuario is Socio s)
            {
                return new AltaUsuarioDto(s.Id, s.NombreCompleto.Nombre, s.NombreCompleto.Apellido, s.Telefono.Value, s.Username.Value, s.VOPassword.Value, "Socio");
            }
            throw new ArgumentException("Tipo de equipo desconocido", nameof(usuario));
        }

        public static IEnumerable<ListarUsuariosDto> ToListDto(IEnumerable<Usuario> usuarios)
        {
            List<ListarUsuariosDto> aux = new List<ListarUsuariosDto>();
            foreach (Usuario item in usuarios)
            {
                aux.Add(toDto(item));
            }
            return aux;
        }
    }
}