namespace StellarMinds.WebApp.Models.Dtos.Usuarios
{
    public record LoginUsuariosDto
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
