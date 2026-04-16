using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.Dtos.NochesObservaciones
{
    public record AltaObservacionDto
    {
        public int IdPrestamo { get; set; }
        public int IdObjetoCeleste { get; set; }
        public DateTime FechaObservacion { get; set; }
    }
}
