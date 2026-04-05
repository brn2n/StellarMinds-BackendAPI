using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.Entidades.Equipos
{
    public class Montura : Equipo
    {
        public TipoMontura TipoMontura { get; set; }
        public double CargaUtilSoportada { get; set; }
        public bool Computarizada { get; set; }

        public Montura(int id, string marca, string modelo, int cantDisponible, TipoMontura tipoMontura, double cargaUtilSoportada, bool computarizada) : base(id, marca, modelo, cantDisponible)
        {
            TipoMontura = tipoMontura;
            CargaUtilSoportada = cargaUtilSoportada;
            Computarizada = computarizada;
        }
    }
}
