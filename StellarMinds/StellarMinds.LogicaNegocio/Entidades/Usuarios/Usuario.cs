using StellarMinds.LogicaNegocio.VO.VOUsuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.Entidades.Usuarios
{
    public abstract class Usuario
    {
        public int Id { get; set; }

        public string NombreCompleto { get; set; }

        public VOTelefono Telefono { get; set; }
    }
}
