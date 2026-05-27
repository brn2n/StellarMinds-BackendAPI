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
    }
}