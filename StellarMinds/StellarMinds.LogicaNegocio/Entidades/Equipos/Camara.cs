using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.Entidades.Equipos
{
    public class Camara : Equipo
    {
        public TipoSensor TipoSensor { get; set; }
        public int Resolucion { get; set; }
        public int TamanioPixel { get; set; }

        public Camara(int id, string marca, string modelo, int cantDisponible, TipoSensor tipoSensor, int resolucion, int tamanioPixel) : base(id, marca, modelo, cantDisponible)
        {
            TipoSensor = tipoSensor;
            Resolucion = resolucion;
            TamanioPixel = tamanioPixel;
        }
    }
}
