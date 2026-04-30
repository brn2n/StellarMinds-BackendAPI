using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.Entidades.Equipos
{
    public class Telescopio : Equipo
    {
        public double Apertura { get; set; }
        public string RelacionFocal { get; set; }
        public double DistanciaFocal { get; set; }
        public double Peso { get; set; }

        public Telescopio(int id, string marca, string modelo, int cantDisponible, double apertura, string relacionFocal, double distanciaFocal, double peso)
            : base(id, marca, modelo, cantDisponible)
        {
            Apertura = apertura;
            RelacionFocal = relacionFocal;
            DistanciaFocal = distanciaFocal;
            Peso = peso;
        }

        public void Update(Telescopio obj)
        {
            base.Update(obj);
            Apertura = obj.Apertura;
            RelacionFocal = obj.RelacionFocal;
            DistanciaFocal= obj.DistanciaFocal;
            Peso = obj.Peso;
        }
    }
}
