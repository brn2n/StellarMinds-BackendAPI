using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class BajaEquipo
    {
        private IRepositorioEquipo _repo;


        public BajaEquipo (IRepositorioEquipo repo)
        {
            _repo = repo;
        }
        public void Execute(int id)
        {
            _repo.Delete(id);
        }
    }
}
