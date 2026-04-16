
namespace StellarMinds.Infraestructura.InterfacesRepositorio
{
    public interface IRepositorioGetAll<T>
    {
        IEnumerable<T> GetAll();
    }
}
