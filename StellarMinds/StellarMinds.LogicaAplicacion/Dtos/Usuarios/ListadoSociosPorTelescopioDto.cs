using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.Dtos.Usuarios
{
    public record ListadoSociosPorTelescopioDto
    {
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
    }
}
