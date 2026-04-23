using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
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

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipo> GetAll()
        {
            return _equipos;
        }

        public Equipo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Equipo obj)
        {
            throw new NotImplementedException();
        }
    }
}
