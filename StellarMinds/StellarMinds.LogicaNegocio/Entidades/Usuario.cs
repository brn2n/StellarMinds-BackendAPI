using StellarMinds.LogicaNegocio.VO.VOUsuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }

        public NombreCompleto NombreCompleto { get; set; }

        public VOTelefono Telefono { get; set; }
    }
}
