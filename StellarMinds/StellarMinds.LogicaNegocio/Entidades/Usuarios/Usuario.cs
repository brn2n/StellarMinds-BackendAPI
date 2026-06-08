using StellarMinds.LogicaNegocio.Excepciones.EntidadesException.UsuarioException;
using StellarMinds.LogicaNegocio.VO.VOUsuario;

namespace StellarMinds.LogicaNegocio.Entidades.Usuarios
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public VONombreCompleto NombreCompleto { get; private set; }
        public VOTelefono Telefono { get; set; }
        public VOUsername Username { get; set; }
        public VOPassword VOPassword { get; set; }

        protected Usuario()
        {
        }

        protected Usuario(int id, VONombreCompleto nombreCompleto, VOTelefono telefono, VOUsername username, VOPassword vOPassword)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
            Telefono = telefono;
            Username = username;
            VOPassword = vOPassword;
            Validar();
        }

        private void Validar()
        {
            if (Username == null || Telefono == null || VOPassword == null || NombreCompleto == null)
            {
                throw new UserInvalidException("Los campos no pueden ser nulos.");
            }
        }
    }
}
