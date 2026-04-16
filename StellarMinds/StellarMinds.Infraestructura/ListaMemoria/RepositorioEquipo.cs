using StellarMinds.Infraestructura.InterfacesRepositorio;
using StellarMinds.LogicaNegocio.Entidades.Equipos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Infraestructura.ListaMemoria
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
            private static List<Equipo> _equipos { get; set; } = new List<Equipo>();

        public void Add(Equipo equipo)
            {
                _equipos.Add(equipo);
            }

        public IEnumerable<Equipo> GetAll()
        {
            return _equipos;
        }
    }
}
