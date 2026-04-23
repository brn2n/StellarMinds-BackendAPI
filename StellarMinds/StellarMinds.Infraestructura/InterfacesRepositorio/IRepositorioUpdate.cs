namespace StellarMinds.Infraestructura.InterfacesRepositorio
{
    public interface IRepositorioUpdate<T>
    {
        void Update(int id, T obj);
    }
}
