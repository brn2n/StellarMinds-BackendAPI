using StellarMinds.LogicaNegocio.Entidades.ObjetosCelestes;

namespace StellarMinds.Infraestructura.InterfacesRepositorio.ObjetosCelestes
{
    public interface IRepositorioObjetosCelestes : IRepositorioAdd<ObjetoCeleste>, IRepositorioGetAll<ObjetoCeleste>, IRepositorioGetById<ObjetoCeleste>
    {
    }
}
