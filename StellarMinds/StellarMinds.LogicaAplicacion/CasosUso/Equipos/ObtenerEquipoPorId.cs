using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaAplicacion.Mapper;
using StellarMinds.LogicaNegocio.Entidades.Equipos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class ObtenerEquipoPorId : ICUGetById<ListarEquipoDto>
    {
        private IRepositorioEquipo _repo;

        public ObtenerEquipoPorId(IRepositorioEquipo repo)
        {
            _repo = repo;
        }

        public ListarEquipoDto Execute(int id)
        {
            return EquipoMapper.toDto(_repo.GetById(id));
        }
    }
}
