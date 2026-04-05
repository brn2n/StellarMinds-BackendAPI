using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.Entidades.Equipos
{
    public abstract class Equipo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantDisponible { get; set; }
        
        protected Equipo()
        {
            
        }

        protected Equipo(int id, string marca, string modelo, int cantDisponible)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            CantDisponible = cantDisponible;
        }
    }
}
