using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.LogicaAplicacion.Dtos.Equipos.StellarMinds.LogicaAplicacion.Dtos.Equipos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class EditarEquipo
    {
        private IRepositorioEquipo _repo;

        public EditarEquipo(IRepositorioEquipo repo)
        {
            _repo = repo;
        }


        public void Execute(int id, AltaEquipoDto Obj)
        {
            //_repo.Update(id, AutorMapper.FromDto(Obj));
        }
    }
}
