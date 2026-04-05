using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes
{
    public class ObjetoCeleste
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Magnitud { get; set; }

        private ObjetoCeleste()
        {
            
        }

        public ObjetoCeleste(string nombre, string tipo, int magnitud)
        {
            Nombre = nombre;
            Tipo = tipo;
            Magnitud = magnitud;
        }
    }
}
