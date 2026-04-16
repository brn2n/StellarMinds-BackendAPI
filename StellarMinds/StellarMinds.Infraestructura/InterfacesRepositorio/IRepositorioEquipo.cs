using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.Infraestructura.InterfacesRepositorio
{
    public interface IRepositorioEquipo : IRepositorioAdd<Equipo>,
                                        IRepositorioGetAll<Equipo>
    {
    }
}
