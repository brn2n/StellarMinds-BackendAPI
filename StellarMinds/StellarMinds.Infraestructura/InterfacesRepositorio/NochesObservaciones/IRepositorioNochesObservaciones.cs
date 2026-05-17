using StellarMinds.LogicaNegocio.Entidades.NochesObservaciones;

namespace StellarMinds.Infraestructura.InterfacesRepositorio.NochesObservaciones
{
    public interface IRepositorioNochesObservaciones : IRepositorioAdd<NocheObservacion>, IRepositorioGetAll<NocheObservacion>, IRepositorioGetById<NocheObservacion>
    {
    }
}
