namespace StellarMinds.LogicaAplicacion.Dtos.Usuarios
{
    public record AltaUsuarioDto(int Id, string nombre, string apellido, int telefono, string username, string password, string rol)
    {
    }
}
