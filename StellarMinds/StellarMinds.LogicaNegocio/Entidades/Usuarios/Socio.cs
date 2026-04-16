using StellarMinds.LogicaNegocio.VO.VOUsuario;

namespace StellarMinds.LogicaNegocio.Entidades.Usuarios;

public class Socio : Usuario
{
    public Socio(int id, VONombreCompleto nombreCompleto, VOTelefono telefono, VOUsername username, VOPassword vOPassword) : base(id, nombreCompleto, telefono, username, vOPassword)
    {
    }
}