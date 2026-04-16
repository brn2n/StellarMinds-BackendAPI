using StellarMinds.LogicaNegocio.VO.VOUsuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.Dtos.Usuarios
{
    public record AltaSocioDto (int Id, string nombre, string apellido, int telefono, string username, string password)
    {
    }
}
