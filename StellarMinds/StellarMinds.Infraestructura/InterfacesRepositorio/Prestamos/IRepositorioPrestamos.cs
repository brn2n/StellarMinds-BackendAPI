using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos
{
    public interface IRepositorioPrestamos : IRepositorioAdd<Prestamo>, IRepositorioGetAll<Prestamo>, IRepositorioGetById<Prestamo>, IRepositorioUpdate<Prestamo>
    {
        bool EnPrestamo(int id);
    }
}
