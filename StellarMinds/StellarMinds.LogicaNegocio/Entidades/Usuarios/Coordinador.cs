using StellarMinds.LogicaNegocio.VO.VOUsuario;

namespace StellarMinds.LogicaNegocio.Entidades.Usuarios;

public class Coordinador : Usuario
{
    public Coordinador(int id, VONombreCompleto nombreCompleto, VOTelefono telefono, VOUsername username, VOPassword vOPassword) : base(id, nombreCompleto, telefono, username, vOPassword)
    {
    }
    protected Coordinador() { }

}