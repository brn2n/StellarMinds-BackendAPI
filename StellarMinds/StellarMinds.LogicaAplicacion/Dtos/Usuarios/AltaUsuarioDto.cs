using StellarMinds.LogicaNegocio.VO.VOUsuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.Dtos.Usuarios
{
    public record AltaUsuarioDto (int Id, string nombre, string apellido, int telefono, string username, string password, string rol)
    {
    }
}
