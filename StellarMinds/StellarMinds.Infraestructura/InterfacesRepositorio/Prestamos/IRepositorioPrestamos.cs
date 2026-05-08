using StellarMinds.LogicaNegocio.Entidades.Prestamos;

namespace StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos
{
    public interface IRepositorioPrestamos : IRepositorioGetAll<Prestamo>, IRepositorioAdd<Prestamo>
    {
        bool EnPrestamo(int id);
    }
}
