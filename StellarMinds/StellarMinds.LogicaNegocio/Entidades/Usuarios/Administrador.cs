using StellarMinds.LogicaNegocio.VO.VOUsuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.Entidades.Usuarios
{
    public class Administrador : Usuario
    {
        public Administrador(int id, VONombreCompleto nombreCompleto, VOTelefono telefono, VOUsername username, VOPassword vOPassword) : base(id, nombreCompleto, telefono, username, vOPassword)
        {
        }
    }
}
