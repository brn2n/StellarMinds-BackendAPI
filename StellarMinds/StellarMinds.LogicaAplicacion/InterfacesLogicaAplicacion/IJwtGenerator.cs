
namespace StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion
{
    public interface IJwtGenerator<T>
    {
        string GenerateToken(T JWTUsuarioDto);
    }
}
