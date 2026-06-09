using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.Dtos.NochesObservaciones
{
    public record AltaObservacionDto
    {
        public int SocioId { get; set; }
        public int PrestamoId { get; set; }
        public int ObjetoCelesteId { get; set; }
        public DateTime FechaObservacion { get; set; }
    }
}
