using StellarMinds.LogicaNegocio.Entidades.Equipos;
using StellarMinds.LogicaNegocio.VO.Prestamos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.Entidades.Prestamos
{
    public class Prestamo
    {
        public DateTime fechaInicio { get; set; } = DateTime.Now;
        public VOFechaFin VOFechaFin { get; set; }
        public Montura Montura { get; set; }
        public Ocular Ocular { get; set; }
        public Telescopio Telescopio { get; set; }
        public Camara Camara { get; set; }

        public Prestamo()
        {
            
        }
    }
}
