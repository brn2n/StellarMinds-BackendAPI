using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.Entidades.Equipos
{
    public abstract class Equipo
    {
        public int id { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int cantDisponible { get; set; }

        protected Equipo()
        {
            
        }
    }
}
