using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;

namespace StellarMinds.LogicaAplicacion.CasosUso.Equipos
{
    public class EditarEquipo
    {
        private IRepositorioEquipo _repo;

        public EditarEquipo(IRepositorioEquipo repo)
        {
            _repo = repo;
        }


        // public void Execute(int id, AltaEquipoDto Obj)
        //{
        //_repo.Update(id, AutorMapper.FromDto(Obj));
        //}
    }
}
