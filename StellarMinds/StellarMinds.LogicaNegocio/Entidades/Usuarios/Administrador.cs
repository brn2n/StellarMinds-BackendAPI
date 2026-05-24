using StellarMinds.LogicaNegocio.VO.VOUsuario;

namespace StellarMinds.LogicaNegocio.Entidades.Usuarios
{
    public class Administrador : Usuario
    {
        public Administrador(int id, VONombreCompleto nombreCompleto, VOTelefono telefono, VOUsername username, VOPassword vOPassword) : base(id, nombreCompleto, telefono, username, vOPassword)
        {
        }
        protected Administrador() { }
    }
}
