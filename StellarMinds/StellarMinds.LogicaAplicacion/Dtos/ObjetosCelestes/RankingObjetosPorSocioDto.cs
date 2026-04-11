using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.Dtos.ObjetosCelestes
{
    public record RankingObjetosPorSocioDto
    {
        public string NombreObjeto { get; set; }
        public string Tipo { get; set; }
        public int CantidadObservaciones { get; set; }
    }
}
