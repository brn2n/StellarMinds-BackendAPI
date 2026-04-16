using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.Dtos.Usuarios
{
    public record LoginUsuariosDto
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
