using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.Infraestructura.InterfacesRepositorio.Equipos
{
    public interface IRepositorioEquipo : IRepositorioAdd<Equipo>, IRepositorioDelete<Equipo>, IRepositorioGetAll<Equipo>, IRepositorioUpdate<Equipo>, IRepositorioGetById<Equipo>
    {
    }
}
