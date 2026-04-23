namespace StellarMinds.Infraestructura.InterfacesRepositorio
{
    public interface IRepositorioGetById<T>
    {
        T GetById(int id);
    }
}
