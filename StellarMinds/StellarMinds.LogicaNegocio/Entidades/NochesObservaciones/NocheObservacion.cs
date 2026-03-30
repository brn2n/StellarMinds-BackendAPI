using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.Entidades.NochesObservaciones
{
    public class NocheObservacion
    {
        public DateTime fechaObservacion { get; set; }
        public Prestamo Prestamo { get; set; }
        public ObjetoCeleste ObjetoCeleste { get; set; }

        public NocheObservacion()
        {
            
        }
    }
}
