using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.LogicaNegocio.Entidades.Equipos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class ListarEquipos
    {
        private IRepositorioEquipo _repo;

        public ListarEquipos(IRepositorioEquipo repo)
        {
            _repo = repo;
        }

        public IEnumerable<Equipo> Execute()
        {
            return _repo.GetAll();
        }
    }
}
