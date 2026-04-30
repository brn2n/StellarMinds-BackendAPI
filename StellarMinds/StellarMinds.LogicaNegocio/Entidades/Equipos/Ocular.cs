using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.Entidades.Equipos
{
    public class Ocular : Equipo
    {
        public double Diametro { get; set; }
        public int AnguloVision { get; set; }

        public Ocular(int id, string marca, string modelo, int cantDisponible, double diametro, int anguloVision) : base(id, marca, modelo, cantDisponible)
        {
            Diametro = diametro;
            AnguloVision = anguloVision;
        }

        public void Update(Ocular obj)
        {
            base.Update(obj);
            Diametro = obj.Diametro;
            AnguloVision = obj.AnguloVision;
        }
    }
}
