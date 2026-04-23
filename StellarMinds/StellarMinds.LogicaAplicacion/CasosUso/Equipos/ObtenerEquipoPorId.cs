using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Equipos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class ObtenerEquipoPorId : ICUGetById<Equipo>
    {
        private IRepositorioEquipo _repo;

        public ObtenerEquipoPorId(IRepositorioEquipo repo)
        {
            _repo = repo;
        }

        public Equipo Execute(int id)
        {
            return _repo.GetById(id);
        }
    }
}
