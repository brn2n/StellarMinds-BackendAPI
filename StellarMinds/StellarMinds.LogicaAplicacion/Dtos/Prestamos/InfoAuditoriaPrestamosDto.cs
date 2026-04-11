using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.Dtos.Prestamos
{
    public record InfoAuditoriaPrestamosDto
    {
        public int IdPrestamo { get; set; }
        public string UsuarioCoordinador { get; set; }
        public DateTime Fecha { get; set; }
    }
}
